using AutoMapper;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<AttendanceService>? _logger;
        private readonly IPermissionService? _permissionService;
        private readonly IAuthService? _authService;
        private readonly AppDbContext _db;

        public AttendanceService(
            IAttendanceRepository repo, 
            IEmployeeRepository employeeRepo, 
            IMapper mapper,
            AppDbContext db,
            ILogger<AttendanceService>? logger = null,
            IPermissionService? permissionService = null,
            IAuthService? authService = null)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _db = db;
            _logger = logger;
            _permissionService = permissionService;
            _authService = authService;
        }

        // Helper: Lấy danh sách employeeId mà user có quyền thao tác trên module Attendance
        private async Task<HashSet<int>> GetAllowedEmployeeIdsAsync(int accountId, int? currentEmployeeId, CancellationToken ct = default)
        {
            var allowedIds = new HashSet<int>();
            if (_permissionService == null) return allowedIds;

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

                if (module != ModuleName.Attendance || (actions & PermissionAction.View) == 0) continue;

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

        // Permission check for specific action and employee
        private async Task<bool> HasPermissionForEmployeeAsync(int accountId, int? currentEmployeeId, int targetEmployeeId, PermissionAction action, CancellationToken ct = default)
        {
            if (_permissionService == null) return false;
            var allowedIds = await GetAllowedEmployeeIdsAsync(accountId, currentEmployeeId, ct);
            return allowedIds.Contains(targetEmployeeId);
        }

        public async Task<AttendanceRecordDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) return null;
            var userInfo = _authService?.GetUserInfoFromToken();
            DeconstructUserInfo(userInfo, out var accountId, out var isMaster, out var employeeId);
            if (isMaster) return _mapper.Map<AttendanceRecordDto>(entity);
            if (!accountId.HasValue) return null;
            var hasPerm = await HasPermissionForEmployeeAsync(accountId.Value, employeeId, entity.EmployeeId, PermissionAction.View, ct);
            if (!hasPerm) return null;
            return _mapper.Map<AttendanceRecordDto>(entity);
        }

        public async Task<List<AttendanceRecordDto>> QueryAsync(
            int? empId = null,
            int? shiftAssignmentId = null,
            int? shiftTypeId = null,
            DateTime? date = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            bool? isOvertime = null,
            int? teamId = null,
            CancellationToken ct = default)
        {
            Console.WriteLine("Đây là phần in ra các attendacnce từ repo");
            var userInfo = _authService?.GetUserInfoFromToken();
            DeconstructUserInfo(userInfo, out var accountId, out var isMaster, out var currentEmployeeId);
            Console.WriteLine("Đây là phần in ra các attendacnce từ repo");

            List<AttendanceRecord> records;
            if (isMaster)
            {
                records = await _repo.QueryAsync(empId, shiftAssignmentId, shiftTypeId, date, dateFrom, dateTo, isOvertime, ct);
                if (teamId.HasValue)
                {
                    var teamEmployeeIds = await _db.TeamMembers.Where(tm => tm.TeamId == teamId.Value).Select(tm => tm.EmployeeId).ToListAsync(ct);
                    records = records.Where(r => teamEmployeeIds.Contains(r.EmployeeId)).ToList();
                }
                Console.WriteLine("Đây là phần in ra các attendacnce từ repo đã có: " +records.Count.ToString() + " được tìm thấy");
                Helper.PrintJson(records);
                return _mapper.Map<List<AttendanceRecordDto>>(records);
            }
            if (!accountId.HasValue) return new List<AttendanceRecordDto>();
            var allowedIds = await GetAllowedEmployeeIdsAsync(accountId.Value, currentEmployeeId, ct);
            var recordsAll = await _repo.QueryAsync(empId, shiftAssignmentId, shiftTypeId, date, dateFrom, dateTo, isOvertime, ct);
            if (teamId.HasValue)
            {
                var teamEmployeeIds = await _db.TeamMembers.Where(tm => tm.TeamId == teamId.Value).Select(tm => tm.EmployeeId).ToListAsync(ct);
                recordsAll = recordsAll.Where(r => teamEmployeeIds.Contains(r.EmployeeId)).ToList();
            }
            Helper.PrintJson(recordsAll);
            var filtered = recordsAll.Where(r => allowedIds.Contains(r.EmployeeId)).ToList();
            return _mapper.Map<List<AttendanceRecordDto>>(filtered);
        }

        public async Task<AttendanceRecordDto> CreateAsync(AttendanceRecordDto dto, CancellationToken ct = default)
        {
            var userInfo = _authService?.GetUserInfoFromToken();
            DeconstructUserInfo(userInfo, out var accountId, out var isMaster, out var currentEmployeeId);
            if (!accountId.HasValue)
                throw new UnauthorizedAccessException("Không xác định được người dùng.");
            if (!isMaster)
            {
                var hasPerm = await HasPermissionForEmployeeAsync(accountId.Value, currentEmployeeId, dto.EmployeeId, PermissionAction.Create, ct);
                if (!hasPerm)
                    throw new UnauthorizedAccessException("Bạn không có quyền tạo bản ghi chấm công cho nhân viên này.");
            }
            var entity = new AttendanceRecord
            {
                EmployeeId = dto.EmployeeId,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                ShiftAssignmentId = dto.ShiftAssignmentId,
            };
            await ComputeDurationAndOvertimeAsync(entity);
            var created = await _repo.AddAsync(entity, ct);
            var loaded = await _repo.GetByIdAsync(created.AttendanceRecordId, ct);
            return _mapper.Map<AttendanceRecordDto>(loaded!);
        }

        public async Task<bool> UpdateAsync(AttendanceRecordDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(dto.AttendanceRecordId, ct);
            if (entity == null) return false;
            var userInfo = _authService?.GetUserInfoFromToken();
            DeconstructUserInfo(userInfo, out var accountId, out var isMaster, out var currentEmployeeId);
            if (!accountId.HasValue)
                throw new UnauthorizedAccessException("Không xác định được người dùng.");
            if (!isMaster)
            {
                var hasPerm = await HasPermissionForEmployeeAsync(accountId.Value, currentEmployeeId, entity.EmployeeId, PermissionAction.Edit, ct);
                if (!hasPerm)
                    throw new UnauthorizedAccessException("Bạn không có quyền chỉnh sửa bản ghi chấm công này.");
            }
            entity.CheckIn = dto.CheckIn;
            entity.CheckOut = dto.CheckOut;
            entity.ShiftAssignmentId = dto.ShiftAssignmentId;
            await ComputeDurationAndOvertimeAsync(entity);
            await _repo.UpdateAsync(entity, ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity == null) return false;
            var userInfo = _authService?.GetUserInfoFromToken();
            DeconstructUserInfo(userInfo, out var accountId, out var isMaster, out var currentEmployeeId);
            if (!accountId.HasValue)
                throw new UnauthorizedAccessException("Không xác định được người dùng.");
            if (!isMaster)
            {
                var hasPerm = await HasPermissionForEmployeeAsync(accountId.Value, currentEmployeeId, entity.EmployeeId, PermissionAction.Delete, ct);
                if (!hasPerm)
                    throw new UnauthorizedAccessException("Bạn không có quyền xóa bản ghi chấm công này.");
            }
            await _repo.DeleteAsync(id, ct);
            return true;
        }

        #region Helper Methods

        private async Task ComputeDurationAndOvertimeAsync(AttendanceRecord entity)
        {
            if (entity.CheckOut.HasValue && entity.CheckOut.Value > entity.CheckIn)
            {
                var hours = (decimal)(entity.CheckOut.Value - entity.CheckIn).TotalHours;
                entity.DurationHours = Math.Round(hours, 2);

                try
                {
                    var employee = await _employeeRepo.GetByIdAsync(entity.EmployeeId);
                    if (employee != null)
                    {
                        entity.IsOvertime = entity.DurationHours.HasValue && entity.DurationHours.Value > employee.MaxHoursPerDay;
                        _logger?.LogDebug("Computed overtime for employee {EmployeeId}: {IsOvertime} (Duration: {Duration}h, Max: {MaxHours}h)", 
                            entity.EmployeeId, entity.IsOvertime, entity.DurationHours, employee.MaxHoursPerDay);
                    }
                    else
                    {
                        entity.IsOvertime = false;
                        _logger?.LogWarning("Employee {EmployeeId} not found for overtime calculation", entity.EmployeeId);
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Error computing overtime for employee {EmployeeId}", entity.EmployeeId);
                    entity.IsOvertime = false;
                }
            }
            else
            {
                entity.DurationHours = null;
                entity.IsOvertime = false;
                _logger?.LogDebug("No checkout time or invalid time range for attendance record");
            }
        }

        #endregion

        // Helper để lấy đúng các trường từ userInfo
        private static void DeconstructUserInfo(
            (int? AccountId, string? Username, string? Role, bool IsMaster, int? EmployeeId)? userInfo,
            out int? accountId,
            out bool isMaster,
            out int? employeeId)
                {
                    accountId = null;
                    isMaster = false;
                    employeeId = null;

                    if (userInfo.HasValue)
                    {
                        accountId = userInfo.Value.AccountId;
                        isMaster = userInfo.Value.IsMaster;
                        employeeId = userInfo.Value.EmployeeId;
                    }
                }

        public async Task<AttendanceRecordDto> selfCheck(AttendanceRecordDto dto, CancellationToken ct = default)
        {
            var userInfo = _authService?.GetUserInfoFromToken();
            DeconstructUserInfo(userInfo, out var accountId, out var isMaster, out var employeeId);
            if (!employeeId.HasValue)
                throw new UnauthorizedAccessException("Không xác định được nhân viên.");
            var entity = new AttendanceRecord
            {
                EmployeeId = dto.EmployeeId,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                ShiftAssignmentId = dto.ShiftAssignmentId,
            };
            await ComputeDurationAndOvertimeAsync(entity);
            var created = await _repo.AddAsync(entity, CancellationToken.None);
            var loaded = await _repo.GetByIdAsync(created.AttendanceRecordId, CancellationToken.None);
            return _mapper.Map<AttendanceRecordDto>(loaded!);
        }

        public async Task<AttendanceRecordDto?> selfTodayAttendance(CancellationToken ct = default)
        {
            var userInfo = _authService?.GetUserInfoFromToken();
            DeconstructUserInfo(userInfo, out var accountId, out var isMaster, out var employeeId);
            if (!employeeId.HasValue)
                throw new UnauthorizedAccessException("Không xác định được nhân viên.");
            var today = DateTime.Today;
            var record = await _db.AttendanceRecords
                .Where(r => r.EmployeeId == employeeId.Value && r.CheckIn.Date == today)
                .OrderByDescending(r => r.CheckIn)
                .FirstOrDefaultAsync(ct);
            if (record == null) return null;
            return _mapper.Map<AttendanceRecordDto>(record);
        }

        public async Task<bool> selfCheckOut(CancellationToken ct = default)
        {
            var userInfo = _authService?.GetUserInfoFromToken();
            DeconstructUserInfo(userInfo, out var accountId, out var isMaster, out var employeeId);
            if (!employeeId.HasValue)
                throw new UnauthorizedAccessException("Không xác định được nhân viên.");
            var today = DateTime.Today;
            var record = await _db.AttendanceRecords
                .Where(r => r.EmployeeId == employeeId.Value && r.CheckIn.Date == today && r.CheckOut == null)
                .OrderByDescending(r => r.CheckIn)
                .FirstOrDefaultAsync(ct);
            if (record == null) return false;
            record.CheckOut = DateTime.Now;
            await ComputeDurationAndOvertimeAsync(record);
            await _repo.UpdateAsync(record, ct);
            return true;
        }
    }
}
