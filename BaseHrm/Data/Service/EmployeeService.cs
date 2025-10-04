using AutoMapper;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using BaseHrm.Data.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BaseHrm.Data.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService>? _logger;
        private readonly IPermissionService? _permissionService;
        private readonly IAuthService? _authService;
        private readonly AppDbContext _db;

        public EmployeeService(
            IEmployeeRepository repo, 
            IMapper mapper, 
            AppDbContext db, 
            ILogger<EmployeeService>? logger = null, 
            IPermissionService? permissionService = null, 
            IAuthService? authService = null)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
            _logger = logger;
            _permissionService = permissionService;
            _authService = authService;
        }

        #region Permission Checking

        private async Task<bool> HasPermissionAsync(PermissionAction action, int? employeeId = null)
        {
            // Debug mode bypass
            if (System.Diagnostics.Debugger.IsAttached)
            {
                _logger?.LogWarning("DEBUG MODE: Bypassing permission check");
                return true;
            }

            // Service availability check
            if (!IsPermissionCheckAvailable())
            {
                _logger?.LogWarning("Permission services not available - allowing access for backward compatibility");
                return true;
            }

            try
            {
                var userInfo = GetCurrentUserInfo();
                if (userInfo.IsMaster) return true;
                if (!userInfo.AccountId.HasValue) return false;

                var accountId = userInfo.AccountId.Value;

                // Check permissions in priority order
                if (await HasGlobalPermissionAsync(accountId, action)) return true;
                if (await HasSelfPermissionAsync(accountId, action, employeeId, userInfo.EmployeeId)) return true;
                if (await HasTeamBasedPermissionAsync(accountId, action, employeeId, userInfo.EmployeeId)) return true;

                return false;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error checking permissions for action {Action} on employee {EmployeeId}", action, employeeId);
                return false;
            }
        }

        private bool IsPermissionCheckAvailable()
        {
            return _permissionService != null && _authService != null;
        }

        private (int? AccountId, bool IsMaster, int? EmployeeId) GetCurrentUserInfo()
        {
            var userInfo = _authService!.GetUserInfoFromToken();
            _logger?.LogDebug("User info: AccountId={AccountId}, IsMaster={IsMaster}, EmployeeId={EmployeeId}", 
                userInfo.AccountId, userInfo.IsMaster, userInfo.EmployeeId);
            
            return (userInfo.AccountId, userInfo.IsMaster, userInfo.EmployeeId);
        }

        private async Task<bool> HasGlobalPermissionAsync(int accountId, PermissionAction action)
        {
            var hasGlobal = await _permissionService!.HasPermissionAsync(accountId, ModuleName.Employee, action, ScopeType.Global);
            _logger?.LogDebug("Global permission check for {Action}: {Result}", action, hasGlobal);
            return hasGlobal;
        }

        private async Task<bool> HasSelfPermissionAsync(int accountId, PermissionAction action, int? targetEmployeeId, int? currentEmployeeId)
        {
            if (!targetEmployeeId.HasValue || !currentEmployeeId.HasValue || targetEmployeeId.Value != currentEmployeeId.Value)
                return false;

            var hasSelf = await _permissionService!.HasPermissionAsync(accountId, ModuleName.Employee, action, ScopeType.Self);
            _logger?.LogDebug("Self permission check for {Action}: {Result}", action, hasSelf);
            return hasSelf;
        }

        private async Task<bool> HasTeamBasedPermissionAsync(int accountId, PermissionAction action, int? targetEmployeeId, int? currentEmployeeId)
        {
            if (!targetEmployeeId.HasValue || !currentEmployeeId.HasValue)
                return false;

            try
            {
                var teamRelationship = await GetTeamRelationshipAsync(targetEmployeeId.Value, currentEmployeeId.Value);
                
                // Check OwnTeam permission (user is leader of target's team)
                if (await CheckOwnTeamPermissionAsync(accountId, action, teamRelationship.CommonLeaderTeams))
                    return true;

                // Check Team permission (user and target in same team)
                if (await CheckTeamPermissionAsync(accountId, action, teamRelationship.CommonTeams))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error checking team-based permissions");
                return false;
            }
        }

        private async Task<(List<int> CommonLeaderTeams, List<int> CommonTeams)> GetTeamRelationshipAsync(int targetEmployeeId, int currentEmployeeId)
        {
            // Get target employee's teams
            var targetTeams = await _db.TeamMembers
                .Where(tm => tm.EmployeeId == targetEmployeeId)
                .Select(tm => tm.TeamId)
                .ToListAsync();

            // Get current user's teams (all and leader only)
            var currentUserTeams = await _db.TeamMembers
                .Where(tm => tm.EmployeeId == currentEmployeeId)
                .ToListAsync();

            var currentUserAllTeams = currentUserTeams.Select(tm => tm.TeamId).ToList();
            var currentUserLeaderTeams = currentUserTeams.Where(tm => tm.IsLeader).Select(tm => tm.TeamId).ToList();

            return (
                CommonLeaderTeams: targetTeams.Intersect(currentUserLeaderTeams).ToList(),
                CommonTeams: targetTeams.Intersect(currentUserAllTeams).ToList()
            );
        }

        private async Task<bool> CheckOwnTeamPermissionAsync(int accountId, PermissionAction action, List<int> commonLeaderTeams)
        {
            foreach (var teamId in commonLeaderTeams)
            {
                var hasPermission = await _permissionService!.HasPermissionAsync(
                    accountId, ModuleName.Employee, action, ScopeType.OwnTeam, teamId);
                
                _logger?.LogDebug("OwnTeam permission check for team {TeamId}: {Result}", teamId, hasPermission);
                
                if (hasPermission) return true;
            }
            return false;
        }

        private async Task<bool> CheckTeamPermissionAsync(int accountId, PermissionAction action, List<int> commonTeams)
        {
            foreach (var teamId in commonTeams)
            {
                var hasPermission = await _permissionService!.HasPermissionAsync(
                    accountId, ModuleName.Employee, action, ScopeType.Team, teamId);
                
                _logger?.LogDebug("Team permission check for team {TeamId}: {Result}", teamId, hasPermission);
                
                if (hasPermission) return true;
            }
            return false;
        }

        private async Task<HashSet<int>> GetAllowedEmployeeIdsAsync(int accountId, int? currentEmployeeId)
        {
            var allowedIds = new HashSet<int>();

            // Add self if has self permission
            if (await HasSelfPermissionForSearchAsync(accountId, currentEmployeeId))
            {
                allowedIds.Add(currentEmployeeId!.Value);
            }

            // Add team members based on permissions
            if (currentEmployeeId.HasValue)
            {
                var teamMemberIds = await GetTeamBasedAllowedEmployeesAsync(accountId, currentEmployeeId.Value);
                allowedIds.UnionWith(teamMemberIds);
            }

            return allowedIds;
        }

        private async Task<bool> HasSelfPermissionForSearchAsync(int accountId, int? currentEmployeeId)
        {
            if (!currentEmployeeId.HasValue) return false;

            var hasSelf = await _permissionService!.HasPermissionAsync(accountId, ModuleName.Employee, PermissionAction.View, ScopeType.Self);
            _logger?.LogDebug("Self view permission for search: {Result}", hasSelf);
            return hasSelf;
        }

        private async Task<HashSet<int>> GetTeamBasedAllowedEmployeesAsync(int accountId, int currentEmployeeId)
        {
            var allowedIds = new HashSet<int>();

            try
            {
                var currentUserTeams = await _db.TeamMembers
                    .Where(tm => tm.EmployeeId == currentEmployeeId)
                    .ToListAsync();

                // Check Team scope permissions
                await AddTeamMembersWithPermissionAsync(accountId, currentUserTeams, ScopeType.Team, allowedIds);

                // Check OwnTeam scope permissions (for leader teams)
                var leaderTeams = currentUserTeams.Where(tm => tm.IsLeader).ToList();
                await AddTeamMembersWithPermissionAsync(accountId, leaderTeams, ScopeType.OwnTeam, allowedIds);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error getting team-based allowed employees");
            }

            return allowedIds;
        }

        private async Task AddTeamMembersWithPermissionAsync(int accountId, List<TeamMember> teams, ScopeType scopeType, HashSet<int> allowedIds)
        {
            foreach (var team in teams)
            {
                var hasPermission = await _permissionService!.HasPermissionAsync(
                    accountId, ModuleName.Employee, PermissionAction.View, scopeType, team.TeamId);

                if (hasPermission)
                {
                    var teamMemberIds = await _db.TeamMembers
                        .Where(tm => tm.TeamId == team.TeamId)
                        .Select(tm => tm.EmployeeId)
                        .ToListAsync();

                    allowedIds.UnionWith(teamMemberIds);
                    _logger?.LogDebug("Added {Count} members from team {TeamId} with {ScopeType} permission", 
                        teamMemberIds.Count, team.TeamId, scopeType);
                }
            }
        }

        #endregion

        #region Public Service Methods

        public async Task<List<EmployeeDto>> SearchEmployeesAsync(
            string? name = null,
            string? email = null,
            string? gender = null,
            DateTime? birthDate = null,
            int? positionId = null,
            int? teamId = null,
            CancellationToken ct = default)
        {
            List<Employee> employees;
            if (teamId.HasValue)
            {
                // L?y danh sách nhân viên thu?c team t? TeamService
                employees = await _db.TeamMembers
                    .Where(tm => tm.TeamId == teamId.Value)
                    .Select(tm => tm.Employee)
                    .Distinct()
                    .ToListAsync(ct);
            }
            else
            {
                employees = await _repo.SearchEmployeesAsync();
            }
            if (!string.IsNullOrWhiteSpace(name))
                employees = employees.Where(e => (e.FirstName + " " + e.LastName).Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!string.IsNullOrWhiteSpace(email))
                employees = employees.Where(e => e.Email != null && e.Email.Contains(email, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!string.IsNullOrWhiteSpace(gender))
                employees = employees.Where(e => e.Gender == gender).ToList();
            if (birthDate.HasValue)
                employees = employees.Where(e => e.DateOfBirth.Date == birthDate.Value.Date).ToList();
            if (positionId.HasValue)
                employees = employees.Where(e => e.PositionId == positionId.Value).ToList();
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);

            // Apply permission-based filtering
            dtos = await ApplyPermissionFilteringAsync(dtos, ct);

            // Add working hours calculation
            await AddWorkingHoursCalculationAsync(dtos, ct);

            return dtos;
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            if (!await HasPermissionAsync(PermissionAction.View, id))
            {
                _logger?.LogWarning("Access denied for GetByIdAsync with employee ID: {EmployeeId}", id);
                return null;
            }

            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) return null;

            var dto = _mapper.Map<EmployeeDto>(entity);
            await AddWorkingHoursCalculationAsync(new List<EmployeeDto> { dto }, ct);

            return dto;
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto, CancellationToken ct = default)
        {
            if (!await HasPermissionAsync(PermissionAction.Create))
            {
                _logger?.LogWarning("Access denied for CreateAsync");
                throw new UnauthorizedAccessException("B?n không có quy?n t?o nhân viên m?i.");
            }

            try
            {
                _logger?.LogInformation("Creating new employee");
                
                var entity = _mapper.Map<Employee>(dto);
                await _repo.AddAsync(entity, ct);
                await _repo.SaveChangesAsync(ct);
                
                _logger?.LogInformation("Employee created successfully with ID: {EmployeeId}", entity.EmployeeId);
                return _mapper.Map<EmployeeDto>(entity);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error creating employee");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeDto dto, CancellationToken ct = default)
        {
            if (!await HasPermissionAsync(PermissionAction.Edit, dto.EmployeeId))
            {
                _logger?.LogWarning("Access denied for UpdateAsync with employee ID: {EmployeeId}", dto.EmployeeId);
                throw new UnauthorizedAccessException("B?n không có quy?n ch?nh s?a nhân viên này.");
            }

            var existing = await _repo.GetByIdAsync(dto.EmployeeId, ct);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing, ct);
            await _repo.SaveChangesAsync(ct);
            
            _logger?.LogInformation("Employee updated successfully with ID: {EmployeeId}", dto.EmployeeId);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            if (!await HasPermissionAsync(PermissionAction.Delete, id))
            {
                _logger?.LogWarning("Access denied for DeleteAsync with employee ID: {EmployeeId}", id);
                throw new UnauthorizedAccessException("B?n không có quy?n xóa nhân viên này.");
            }

            var existing = await _repo.GetByIdAsync(id, ct);
            if (existing == null) return false;

            await _repo.DeleteAsync(existing, ct);
            await _repo.SaveChangesAsync(ct);
            
            _logger?.LogInformation("Employee deleted successfully with ID: {EmployeeId}", id);
            return true;
        }

        public async Task<List<EmployeeDto>> GetByTeamAsync(int teamId, CancellationToken ct = default)
        {
            var employees = await _repo.GetByTeamIdAsync(teamId, ct);
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        #endregion

        #region Helper Methods

        private async Task<List<EmployeeDto>> ApplyPermissionFilteringAsync(List<EmployeeDto> dtos, CancellationToken ct)
        {
            if (_authService == null || _permissionService == null) return dtos;

            var (accountId, _, _, isMaster, currentEmployeeId) = _authService.GetUserInfoFromToken();
            
            if (isMaster || !accountId.HasValue) return dtos;

            // Check if user has global view permission
            var hasGlobalView = await _permissionService.HasPermissionAsync(
                accountId.Value, ModuleName.Employee, PermissionAction.View, ScopeType.Global, ct: ct);
            
            if (hasGlobalView) return dtos;

            // Filter based on allowed employee IDs
            var allowedIds = await GetAllowedEmployeeIdsAsync(accountId.Value, currentEmployeeId);
            
            if (!allowedIds.Any())
            {
                _logger?.LogDebug("No employees allowed for user with account ID: {AccountId}", accountId.Value);
                return new List<EmployeeDto>();
            }

            var filteredDtos = dtos.Where(d => allowedIds.Contains(d.EmployeeId)).ToList();
            _logger?.LogDebug("Filtered employees from {OriginalCount} to {FilteredCount} based on permissions", 
                dtos.Count, filteredDtos.Count);

            return filteredDtos;
        }

        private async Task AddWorkingHoursCalculationAsync(List<EmployeeDto> dtos, CancellationToken ct)
        {
            if (!dtos.Any() || _db == null) return;

            try
            {
                var employeeIds = dtos.Select(d => d.EmployeeId).ToArray();
                var now = DateTime.UtcNow;
                var monthStart = new DateTime(now.Year, now.Month, 1);
                var todayStart = now.Date;

                var workingHours = await _db.AttendanceRecords
                    .Where(a => employeeIds.Contains(a.EmployeeId))
                    .GroupBy(a => a.EmployeeId)
                    .Select(g => new
                    {
                        EmployeeId = g.Key,
                        MonthHours = g.Where(x => x.CheckIn >= monthStart).Sum(x => (decimal?)(x.DurationHours)) ?? 0m,
                        TodayHours = g.Where(x => x.CheckIn >= todayStart).Sum(x => (decimal?)(x.DurationHours)) ?? 0m
                    })
                    .ToListAsync(ct);

                foreach (var dto in dtos)
                {
                    var hours = workingHours.FirstOrDefault(h => h.EmployeeId == dto.EmployeeId);
                    if (hours != null)
                    {
                        dto.TotalHoursThisMonth = hours.MonthHours;
                        dto.TotalHoursToday = hours.TodayHours;
                    }
                }

                _logger?.LogDebug("Added working hours calculation for {Count} employees", dtos.Count);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error calculating working hours");
            }
        }

        #endregion
    }
}