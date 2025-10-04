using BaseHrm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _db;
        public AttendanceRepository(AppDbContext db) => _db = db;

        public async Task<AttendanceRecord?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.AttendanceRecords
                .Include(a => a.Employee)
                .Include(a => a.ShiftAssignment)
                    .ThenInclude(sa => sa.Shift)
                .FirstOrDefaultAsync(a => a.AttendanceRecordId == id, ct);
        }

        public async Task<List<AttendanceRecord>> QueryAsync(
            int? employeeId = null,
            int? shiftAssignmentId = null,
            int? shiftTypeId = null,
            DateTime? date = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            bool? isOvertime = null,
            CancellationToken ct = default)
        {
            var q = _db.AttendanceRecords
                .Include(a => a.Employee)
                .Include(a => a.ShiftAssignment).ThenInclude(sa => sa.Shift).ThenInclude(s => s.ShiftType)
                .AsQueryable();

            if (employeeId.HasValue)
                q = q.Where(a => a.EmployeeId == employeeId.Value);

            if (shiftAssignmentId.HasValue)
                q = q.Where(a => a.ShiftAssignmentId == shiftAssignmentId.Value);

            if (date.HasValue)
            {
                var d = date.Value.Date;
                q = q.Where(a => a.CheckIn.Date == d || (a.CheckOut.HasValue && a.CheckOut.Value.Date == d));
            }
            if (shiftTypeId.HasValue)
            {
                q = q.Where(a => a.ShiftAssignment != null && a.ShiftAssignment.Shift != null && a.ShiftAssignment.Shift.ShiftTypeId == shiftTypeId.Value);
            }
            else
            {
                if (dateFrom.HasValue)
                    q = q.Where(a => a.CheckIn.Date >= dateFrom.Value.Date);
                if (dateTo.HasValue)
                    q = q.Where(a => a.CheckIn.Date <= dateTo.Value.Date);
            }

            if (isOvertime.HasValue)
                q = q.Where(a => a.IsOvertime == isOvertime.Value);

            return await q.AsNoTracking().ToListAsync(ct);
        }

        public async Task<AttendanceRecord> AddAsync(AttendanceRecord entity, CancellationToken ct = default)
        {
            await _db.AttendanceRecords.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
            return entity;
        }

        public async Task UpdateAsync(AttendanceRecord entity, CancellationToken ct = default)
        {
            _db.AttendanceRecords.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var ent = await _db.AttendanceRecords.FindAsync(new object[] { id }, ct);
            if (ent != null)
            {
                _db.AttendanceRecords.Remove(ent);
                await _db.SaveChangesAsync(ct);
            }
        }
    }
}
