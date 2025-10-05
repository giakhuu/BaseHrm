using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using BaseHrm.Data.Service;
using BaseHrm.Reports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace BaseHrm.Data.Service
{
    public class BackupRestoreService : IBackupRestoreService
    {
        private readonly AppDbContext _db;
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IShiftRepository _shiftRepo;
        private readonly IShiftAssignmentRepository _shiftAssignmentRepo;
        private readonly AttendanceReportExporter _attendanceExporter;
        private readonly ShiftAssignmentReportExporter _shiftAssignmentExporter;
        // TODO: Add ShiftExporter if needed

        public BackupRestoreService(AppDbContext db, IAttendanceRepository attendanceRepo, IShiftRepository shiftRepo, IShiftAssignmentRepository shiftAssignmentRepo)
        {
            _db = db;
            _attendanceRepo = attendanceRepo;
            _shiftRepo = shiftRepo;
            _shiftAssignmentRepo = shiftAssignmentRepo;
            _attendanceExporter = new AttendanceReportExporter();
            _shiftAssignmentExporter = new ShiftAssignmentReportExporter();
        }

        // Attendance
        public async Task BackupAttendanceAsync(string filePath)
        {
            var records = await _db.AttendanceRecords.Include(r => r.Employee).Include(r => r.ShiftAssignment).ToListAsync();
            var dtos = records.Select(r => new AttendanceRecordDto
            {
                AttendanceRecordId = r.AttendanceRecordId,
                EmployeeId = r.EmployeeId,
                FullName = r.Employee != null ? (r.Employee.FirstName + " " + r.Employee.LastName) : "",
                CheckIn = r.CheckIn,
                CheckOut = r.CheckOut,
                DurationHours = r.DurationHours,
                IsOvertime = r.IsOvertime,
                ShiftAssignmentId = r.ShiftAssignmentId,
                ShiftDate = r.ShiftAssignment?.Date,
                ShiftId = r.ShiftAssignment?.ShiftId,
                ShiftName = r.ShiftAssignment?.Shift?.Name,
                ShiftTypeId = r.ShiftAssignment?.Shift?.ShiftTypeId,
                ShiftTypeName = r.ShiftAssignment?.Shift?.ShiftType?.Name,
                PayMultiplier = r.ShiftAssignment?.Shift?.ShiftType?.PayMultiplier,
                ShiftStart = r.ShiftAssignment?.Shift?.StartTime ?? TimeSpan.Zero,
                ShiftEnd = r.ShiftAssignment?.Shift?.EndTime ?? TimeSpan.Zero,
                EmployeeEmail = r.Employee?.Email,
                EmployeePhone = r.Employee?.Phone,
                EmployeePosition = r.Employee?.Position?.Name,
                EmployeeFirstName = r.Employee?.FirstName,
                EmployeeLastName = r.Employee?.LastName
            }).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task DeleteAllAttendanceAsync()
        {
            var all = await _db.AttendanceRecords.ToListAsync();
            _db.AttendanceRecords.RemoveRange(all);
            await _db.SaveChangesAsync();
        }

        public async Task RestoreAttendanceAsync(string filePath)
        {
            var json = await File.ReadAllTextAsync(filePath);
            var imported = JsonSerializer.Deserialize<List<AttendanceRecordDto>>(json);
            if (imported == null || imported.Count == 0) return;

            // Lấy danh sách các Id đã tồn tại
            var existingIds = await _db.AttendanceRecords.Select(x => x.AttendanceRecordId).ToListAsync();
            var entities = imported
                .Where(dto => !existingIds.Contains(dto.AttendanceRecordId))
                .Select(dto => new AttendanceRecord
                {
                    AttendanceRecordId = dto.AttendanceRecordId,
                    EmployeeId = dto.EmployeeId,
                    CheckIn = dto.CheckIn,
                    CheckOut = dto.CheckOut,
                    DurationHours = dto.DurationHours,
                    IsOvertime = dto.IsOvertime,
                    ShiftAssignmentId = dto.ShiftAssignmentId
                }).ToList();

            if (entities.Count == 0) return;

            var prevAutoDetect = _db.ChangeTracker.AutoDetectChangesEnabled;
            _db.ChangeTracker.AutoDetectChangesEnabled = false;
            await _db.Database.OpenConnectionAsync();
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[AttendanceRecords] ON;");
                _db.AttendanceRecords.AddRange(entities);
                await _db.SaveChangesAsync();
                await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[AttendanceRecords] OFF;");
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                try { await transaction.RollbackAsync(); } catch { /* ignore rollback failure */ }
                throw;
            }
            finally
            {
                _db.ChangeTracker.AutoDetectChangesEnabled = prevAutoDetect;
                try
                {
                    await _db.Database.ExecuteSqlRawAsync(
                        "IF (OBJECT_ID('dbo.AttendanceRecords') IS NOT NULL) SET IDENTITY_INSERT [dbo].[AttendanceRecords] OFF;");
                }
                catch { }
                await _db.Database.CloseConnectionAsync();
            }
        }

        // Shift
        public async Task BackupShiftAndAssignmentAsync(string filePath)
        {
            var shifts = await _db.Shifts.Include(s => s.ShiftType).ToListAsync();
            var shiftDtos = shifts.Select(s => new ShiftDto
            {
                ShiftId = s.ShiftId,
                Name = s.Name,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                ExpectedHours = s.ExpectedHours,
                ShiftTypeId = s.ShiftTypeId,
                ShiftTypeName = s.ShiftType?.Name,
                PayMultiplier = s.ShiftType?.PayMultiplier
            }).ToList();

            var assignments = await _db.ShiftAssignments.Include(a => a.Employee).Include(a => a.Shift).ThenInclude(s => s.ShiftType).Include(a => a.ApprovedByAccount).ToListAsync();
            var assignmentDtos = assignments.Select(a => new ShiftAssignmentDto
            {
                ShiftAssignmentId = a.ShiftAssignmentId,
                EmployeeId = a.EmployeeId,
                EmployeeFirstName = a.Employee?.FirstName ?? "",
                EmployeeLastName = a.Employee?.LastName ?? "",
                EmployeeEmail = a.Employee?.Email,
                EmployeePhone = a.Employee?.Phone,
                EmployeePosition = a.Employee?.Position?.Name,
                ShiftId = a.ShiftId,
                ShiftName = a.Shift?.Name,
                ShiftStart = a.Shift?.StartTime ?? TimeSpan.Zero,
                ShiftEnd = a.Shift?.EndTime ?? TimeSpan.Zero,
                ExpectedHours = a.Shift?.ExpectedHours ?? 0,
                ShiftTypeId = a.Shift?.ShiftTypeId,
                ShiftTypeName = a.Shift?.ShiftType?.Name,
                PayMultiplier = a.Shift?.ShiftType?.PayMultiplier,
                Date = a.Date,
                ApprovedByAccountId = a.ApprovedByAccountId,
                ApproverName = a.ApprovedByAccount?.Username
            }).ToList();

            var backup = new ShiftBackupDto
            {
                Shifts = shiftDtos,
                ShiftAssignments = assignmentDtos
            };
            var json = JsonSerializer.Serialize(backup, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task DeleteAllShiftAndAssignmentAsync()
        {
            var allAssignments = await _db.ShiftAssignments.ToListAsync();
            _db.ShiftAssignments.RemoveRange(allAssignments);
            var allShifts = await _db.Shifts.ToListAsync();
            _db.Shifts.RemoveRange(allShifts);
            await _db.SaveChangesAsync();
        }

        public async Task RestoreShiftAndAssignmentAsync(string filePath)
        {
            var json = await File.ReadAllTextAsync(filePath);
            var backup = JsonSerializer.Deserialize<ShiftBackupDto>(json);
            if (backup == null) return;

            // Restore Shifts (chỉ insert ShiftId chưa tồn tại)
            if (backup.Shifts != null && backup.Shifts.Count > 0)
            {
                var existingShiftIds = await _db.Shifts.Select(s => s.ShiftId).ToListAsync();
                var shiftEntities = backup.Shifts
                    .Where(dto => !existingShiftIds.Contains(dto.ShiftId))
                    .Select(dto => new Shift
                    {
                        ShiftId = dto.ShiftId,
                        Name = dto.Name ?? "",
                        StartTime = dto.StartTime,
                        EndTime = dto.EndTime,
                        ExpectedHours = dto.ExpectedHours,
                        ShiftTypeId = dto.ShiftTypeId
                    }).ToList();
                if (shiftEntities.Count > 0)
                {
                    var prevAutoDetect = _db.ChangeTracker.AutoDetectChangesEnabled;
                    _db.ChangeTracker.AutoDetectChangesEnabled = false;
                    await _db.Database.OpenConnectionAsync();
                    using var transaction = await _db.Database.BeginTransactionAsync();
                    try
                    {
                        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Shifts] ON;");
                        _db.Shifts.AddRange(shiftEntities);
                        await _db.SaveChangesAsync();
                        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Shifts] OFF;");
                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        try { await transaction.RollbackAsync(); } catch { }
                        throw;
                    }
                    finally
                    {
                        _db.ChangeTracker.AutoDetectChangesEnabled = prevAutoDetect;
                        try
                        {
                            await _db.Database.ExecuteSqlRawAsync(
                                "IF (OBJECT_ID('dbo.Shifts') IS NOT NULL) SET IDENTITY_INSERT [dbo].[Shifts] OFF;");
                        }
                        catch { }
                        await _db.Database.CloseConnectionAsync();
                    }
                }
            }

            // Restore ShiftAssignments (chỉ insert ShiftAssignmentId chưa tồn tại)
            if (backup.ShiftAssignments != null && backup.ShiftAssignments.Count > 0)
            {
                var existingAssignmentIds = await _db.ShiftAssignments.Select(a => a.ShiftAssignmentId).ToListAsync();
                var assignmentEntities = backup.ShiftAssignments
                    .Where(dto => !existingAssignmentIds.Contains(dto.ShiftAssignmentId))
                    .Select(dto => new ShiftAssignment
                    {
                        ShiftAssignmentId = dto.ShiftAssignmentId,
                        EmployeeId = dto.EmployeeId,
                        ShiftId = dto.ShiftId,
                        Date = dto.Date,
                        ApprovedByAccountId = dto.ApprovedByAccountId
                    }).ToList();
                if (assignmentEntities.Count > 0)
                {
                    var prevAutoDetect = _db.ChangeTracker.AutoDetectChangesEnabled;
                    _db.ChangeTracker.AutoDetectChangesEnabled = false;
                    await _db.Database.OpenConnectionAsync();
                    using var transaction = await _db.Database.BeginTransactionAsync();
                    try
                    {
                        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[ShiftAssignments] ON;");
                        _db.ShiftAssignments.AddRange(assignmentEntities);
                        await _db.SaveChangesAsync();
                        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[ShiftAssignments] OFF;");
                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        try { await transaction.RollbackAsync(); } catch { }
                        throw;
                    }
                    finally
                    {
                        _db.ChangeTracker.AutoDetectChangesEnabled = prevAutoDetect;
                        try
                        {
                            await _db.Database.ExecuteSqlRawAsync(
                                "IF (OBJECT_ID('dbo.ShiftAssignments') IS NOT NULL) SET IDENTITY_INSERT [dbo].[ShiftAssignments] OFF;");
                        }
                        catch { }
                        await _db.Database.CloseConnectionAsync();
                    }
                }
            }
        }
    }

    // TODO: Implement Importers/Exporters for Excel (AttendanceExcelImporter, ShiftExcelExporter, etc.)
}
