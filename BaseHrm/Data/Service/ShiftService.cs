using AutoMapper;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using BaseHrm.Data.Service;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepo;
        private readonly IShiftTypeRepository _typeRepo;
        private readonly IShiftAssignmentRepository _assignRepo;
        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;
        private readonly AppDbContext _db;
        private readonly IAuthService _authService;
        private readonly ITeamService _teamService;
        private readonly IPermissionService _permissionService;

        public ShiftService(
            IShiftRepository shiftRepo,
            IShiftTypeRepository typeRepo,
            IShiftAssignmentRepository assignRepo,
            IAccountRepository accountRepo,
            IMapper mapper,
            AppDbContext db,
            IAuthService authService,
            ITeamService teamService,
            IPermissionService permissionService)
        {
            _shiftRepo = shiftRepo;
            _typeRepo = typeRepo;
            _assignRepo = assignRepo;
            _accountRepo = accountRepo;
            _mapper = mapper;
            _db = db;
            _authService = authService;
            _teamService = teamService;
            _permissionService = permissionService;
        }

        // Helper: Lấy danh sách employeeId mà user có quyền thao tác trên module Shift
        private async Task<HashSet<int>> GetAllowedEmployeeIdsAsync(int accountId, int? currentEmployeeId, CancellationToken ct = default)
        {
            var allowedIds = new HashSet<int>();

            // Lấy tất cả RolePermission và AccountPermission của user
            var (accountPerms, rolePerms) = await _permissionService.GetEffectivePermissionsAsync(accountId, ct);
            var allPerms = accountPerms.Cast<object>().Concat(rolePerms);

            foreach (var permObj in allPerms)
            {
                ScopeType scopeType;
                int? scopeValue;
                ModuleName module;
                PermissionAction actions;
                if (permObj is AccountPermission ap)
                {
                    scopeType = ap.ScopeType;
                    scopeValue = ap.ScopeValue;
                    module = ap.Module;
                    actions = ap.Actions;
                }
                else if (permObj is RolePermission rp)
                {
                    scopeType = rp.ScopeType;
                    scopeValue = rp.ScopeValue;
                    module = rp.Module;
                    actions = rp.Actions;
                }
                else continue;

                if (module != ModuleName.Shift || (actions & PermissionAction.View) == 0) continue;

                switch (scopeType)
                {
                    case ScopeType.Global:
                        var allIds = await _db.Employees.Select(e => e.EmployeeId).ToListAsync(ct);
                        allowedIds.UnionWith(allIds);
                        break;
                    case ScopeType.Team:
                        if (scopeValue.HasValue)
                        {
                            var teamMemberIds = await _db.TeamMembers
                                .Where(tm => tm.TeamId == scopeValue.Value)
                                .Select(tm => tm.EmployeeId)
                                .ToListAsync(ct);
                            allowedIds.UnionWith(teamMemberIds);
                        }
                        break;
                    case ScopeType.OwnTeam:
                        if (scopeValue.HasValue && currentEmployeeId.HasValue)
                        {
                            var isLeader = await _db.TeamMembers.AnyAsync(tm => tm.TeamId == scopeValue.Value && tm.EmployeeId == currentEmployeeId.Value && tm.IsLeader, ct);
                            if (isLeader)
                            {
                                var teamMemberIds = await _db.TeamMembers
                                    .Where(tm => tm.TeamId == scopeValue.Value)
                                    .Select(tm => tm.EmployeeId)
                                    .ToListAsync(ct);
                                allowedIds.UnionWith(teamMemberIds);
                            }
                        }
                        break;
                    case ScopeType.Self:
                        if (currentEmployeeId.HasValue)
                            allowedIds.Add(currentEmployeeId.Value);
                        break;
                }
            }
            return allowedIds;
        }

        public async Task<ShiftTypeDto> CreateShiftTypeAsync(ShiftTypeDto dto, CancellationToken ct = default)
        {
            var ent = _mapper.Map<ShiftType>(dto);
            var created = await _typeRepo.AddAsync(ent, ct);
            return _mapper.Map<ShiftTypeDto>(created);
        }

        public async Task<bool> DeleteShiftTypeAsync(int id, CancellationToken ct = default)
        {
            var existing = await _typeRepo.GetByIdAsync(id, ct);
            if (existing == null) return false;
            await _typeRepo.DeleteAsync(id, ct);
            return true;
        }

        public async Task<List<ShiftTypeDto>> GetAllShiftTypesAsync(CancellationToken ct = default)
        {
            var list = await _typeRepo.GetAllAsync(ct);
            return _mapper.Map<List<ShiftTypeDto>>(list);
        }

        public async Task<bool> UpdateShiftTypeAsync(ShiftTypeDto dto, CancellationToken ct = default)
        {
            var existing = await _typeRepo.GetByIdAsync(dto.ShiftTypeId, ct);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _typeRepo.UpdateAsync(existing, ct);
            return true;
        }

        public async Task<ShiftDto> CreateShiftAsync(ShiftDto dto, CancellationToken ct = default)
        {
            var ent = _mapper.Map<Shift>(dto);
            var created = await _shiftRepo.AddAsync(ent, ct);
            return _mapper.Map<ShiftDto>(created);
        }

        public async Task<bool> DeleteShiftAsync(int id, CancellationToken ct = default)
        {
            var existing = await _shiftRepo.GetByIdAsync(id, ct);
            if (existing == null) return false;
            await _shiftRepo.DeleteAsync(id, ct);
            return true;
        }

        public async Task<List<ShiftDto>> GetAllShiftsAsync(CancellationToken ct = default)
        {
            var list = await _shiftRepo.GetAllAsync(ct);
            return _mapper.Map<List<ShiftDto>>(list);
        }

        public async Task<ShiftDto?> GetShiftByIdAsync(int id, CancellationToken ct = default)
        {
            var ent = await _shiftRepo.GetByIdAsync(id, ct);
            return ent == null ? null : _mapper.Map<ShiftDto>(ent);
        }

        public async Task<bool> UpdateShiftAsync(ShiftDto dto, CancellationToken ct = default)
        {
            var existing = await _shiftRepo.GetByIdAsync(dto.ShiftId, ct);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _shiftRepo.UpdateAsync(existing, ct);
            return true;
        }

        public async Task<List<ShiftAssignmentDto>> QueryAssignmentsAsync(
            int? employeeId = null,
            int? teamId = null,
            DateTime? date = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            int? shiftTypeId = null,
            CancellationToken ct = default)
        {
            var userInfo = _authService.GetUserInfoFromToken();
            if (userInfo.IsMaster)
            {
                var resultList = await _assignRepo.QueryAssignmentsAsync(employeeId, date, dateFrom, dateTo, shiftTypeId, ct);
                if (teamId.HasValue)
                {
                    // Lọc theo teamId
                    var teamEmployeeIds = await _db.TeamMembers.Where(tm => tm.TeamId == teamId.Value).Select(tm => tm.EmployeeId).ToListAsync(ct);
                    resultList = resultList.Where(a => teamEmployeeIds.Contains(a.EmployeeId)).ToList();
                }
                return _mapper.Map<List<ShiftAssignmentDto>>(resultList);
            }

            var allowedIds = await GetAllowedEmployeeIdsAsync(userInfo.AccountId ?? 0, userInfo.EmployeeId, ct);
            var allAssignments = await _assignRepo.QueryAssignmentsAsync(null, date, dateFrom, dateTo, shiftTypeId, ct);
            if (teamId.HasValue)
            {
                var teamEmployeeIds = await _db.TeamMembers.Where(tm => tm.TeamId == teamId.Value).Select(tm => tm.EmployeeId).ToListAsync(ct);
                allAssignments = allAssignments.Where(a => teamEmployeeIds.Contains(a.EmployeeId)).ToList();
            }
            var filtered = allAssignments.Where(a => allowedIds.Contains(a.EmployeeId)).ToList();
            return _mapper.Map<List<ShiftAssignmentDto>>(filtered);
        }

        public async Task<ShiftAssignmentDto> AssignShiftAsync(ShiftAssignmentDto dto, CancellationToken ct = default)
        {
            var userInfo = _authService.GetUserInfoFromToken();
            if (!userInfo.IsMaster)
            {
                var allowedIds = await GetAllowedEmployeeIdsAsync(userInfo.AccountId ?? 0, userInfo.EmployeeId, ct);
                if (!allowedIds.Contains(dto.EmployeeId))
                    throw new UnauthorizedAccessException("Bạn không có quyền gán ca cho nhân viên này.");
                var hasPerm = await _permissionService.HasPermissionAsync(userInfo.AccountId ?? 0, Data.Enums.ModuleName.Shift, Data.Enums.PermissionAction.Create, Data.Enums.ScopeType.Global, null, ct);
                if (!hasPerm)
                    throw new UnauthorizedAccessException("Bạn không có quyền tạo ca làm.");
            }
            var shift = await _shiftRepo.GetByIdAsync(dto.ShiftId, ct);
            if (shift == null)
                throw new InvalidOperationException($"Shift with id={dto.ShiftId} not found.");

            var shiftDate = dto.Date.Date;
            var targetStart = shiftDate + shift.StartTime;
            var targetEnd = shiftDate + shift.EndTime;
            if (targetEnd <= targetStart) 
                targetEnd = targetEnd.AddDays(1);

            var existingAssignments = await _assignRepo.QueryAssignmentsAsync(
                employeeId: dto.EmployeeId,
                dateFrom: dto.Date.AddDays(-1),
                dateTo: dto.Date.AddDays(1),
                ct: ct);

            foreach (var a in existingAssignments)
            {
                var existingShift = await _shiftRepo.GetByIdAsync(a.ShiftId, ct);
                if (existingShift == null) continue; // defensive

                var existingStart = a.Date.Date + existingShift.StartTime;
                var existingEnd = a.Date.Date + existingShift.EndTime;
                if (existingEnd <= existingStart) existingEnd = existingEnd.AddDays(1);

                if (existingStart < targetEnd && existingEnd > targetStart)
                {
                    await DeleteShiftAsync(dto.ShiftAssignmentId, ct);
                    throw new InvalidOperationException(
                        $"Shift conflict: employee {dto.EmployeeId} already has an assignment (shiftId={a.ShiftId}, date={a.Date:yyyy-MM-dd}) that overlaps the requested shift ({dto.ShiftId}, date={dto.Date:yyyy-MM-dd}).");
                }
            }

            var assign = new ShiftAssignment
            {
                EmployeeId = dto.EmployeeId,
                ShiftId = dto.ShiftId,
                Date = dto.Date.Date,
                ApprovedByAccountId = dto.ApprovedByAccountId
            };

            var created = await _assignRepo.AddAsync(assign, ct);
            var loaded = await _assignRepo.GetByIdAsync(created.ShiftAssignmentId, ct);

            return _mapper.Map<ShiftAssignmentDto>(loaded!);
        }

        public async Task<bool> RemoveAssignmentAsync(int shiftAssignmentId, CancellationToken ct = default)
        {
            var userInfo = _authService.GetUserInfoFromToken();
            if (!userInfo.IsMaster)
            {
                var assignment = await _assignRepo.GetByIdAsync(shiftAssignmentId, ct);
                if (assignment == null) return false;
                var allowedIds = await GetAllowedEmployeeIdsAsync(userInfo.AccountId ?? 0, userInfo.EmployeeId, ct);
                if (!allowedIds.Contains(assignment.EmployeeId))
                    throw new UnauthorizedAccessException("Bạn không có quyền xóa ca làm này.");
                var hasPerm = await _permissionService.HasPermissionAsync(userInfo.AccountId ?? 0, Data.Enums.ModuleName.Shift, Data.Enums.PermissionAction.Delete, Data.Enums.ScopeType.Global, null, ct);
                if (!hasPerm)
                    throw new UnauthorizedAccessException("Bạn không có quyền xóa ca làm.");
            }
            var existing = await _assignRepo.GetByIdAsync(shiftAssignmentId, ct);
            if (existing == null) return false;
            await _assignRepo.DeleteAsync(shiftAssignmentId, ct);
            return true;
        }

        public async Task<bool> UpdateAssignmentAsync(ShiftAssignmentDto dto, CancellationToken ct = default)
        {
            var userInfo = _authService.GetUserInfoFromToken();
            if (!userInfo.IsMaster)
            {
                var allowedIds = await GetAllowedEmployeeIdsAsync(userInfo.AccountId ?? 0, userInfo.EmployeeId, ct);
                if (!allowedIds.Contains(dto.EmployeeId))
                    throw new UnauthorizedAccessException("Bạn không có quyền sửa ca làm này.");
                var hasPerm = await _permissionService.HasPermissionAsync(userInfo.AccountId ?? 0, Data.Enums.ModuleName.Shift, Data.Enums.PermissionAction.Edit, Data.Enums.ScopeType.Global, null, ct);
                if (!hasPerm)
                    throw new UnauthorizedAccessException("Bạn không có quyền sửa ca làm.");
            }
            var existing = await _assignRepo.GetByIdAsync(dto.ShiftAssignmentId, ct);
            if (existing == null) return false;
            existing.Date = dto.Date.Date;
            existing.ShiftId = dto.ShiftId;
            existing.EmployeeId = dto.EmployeeId;
            existing.ApprovedByAccountId = dto.ApprovedByAccountId;
            await _assignRepo.UpdateAsync(existing, ct);
            return true;
        }

        public async Task<List<ShiftAssignmentDto>> GetAllShiftAssignmentsAsync(CancellationToken ct = default)
        {
            // Đã loại bỏ đoạn gọi GetAllAsync không tồn tại
            // Nếu cần lấy tất cả ShiftAssignment, hãy dùng QueryAssignmentsAsync với các tham số null
            var list = await _assignRepo.QueryAssignmentsAsync(null, null, null, null, null, ct);
            return _mapper.Map<List<ShiftAssignmentDto>>(list);
        }

        public async Task<ShiftAssignmentDto?> GetAssignmentByIdAsync(int id, CancellationToken ct = default)
        {
            var ent = await _assignRepo.GetByIdWithDetailsAsync(id, ct);
            if (ent == null) return null;

            var dto = _mapper.Map<ShiftAssignmentDto>(ent);

            if (ent.ApprovedByAccountId.HasValue)
            {
                var approver = await _accountRepo.GetByIdAsync(ent.ApprovedByAccountId.Value, ct);
                if (approver != null)
                {
                    var approverName = approver.Employee != null
                        ? $"{approver.Employee.FirstName} {approver.Employee.LastName}"
                        : approver.Username;
                    dto.ApproverName = approverName;
                }
            }

            return dto;
        }
    }
}
