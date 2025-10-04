using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace BaseHrm.Data.Repository
{
    public class ShiftAssignmentRepository : IShiftAssignmentRepository
    {
        private readonly AppDbContext _db;
        public ShiftAssignmentRepository(AppDbContext db) => _db = db;

        public async Task<ShiftAssignment> AddAsync(ShiftAssignment assignment, CancellationToken ct = default)
        {
            await _db.ShiftAssignments.AddAsync(assignment, ct);
            await _db.SaveChangesAsync(ct);
            return assignment;
        }

        public async Task DeleteAsync(int shiftAssignmentId, CancellationToken ct = default)
        {
            var ent = await _db.ShiftAssignments.FindAsync(new object[] { shiftAssignmentId }, ct);
            if (ent != null)
            {
                _db.ShiftAssignments.Remove(ent);
                await _db.SaveChangesAsync(ct);
            }
        }

        public async Task<ShiftAssignment?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.ShiftAssignments
                .Include(sa => sa.Shift).ThenInclude(s => s.ShiftType)
                .Include(sa => sa.Employee)
                .FirstOrDefaultAsync(sa => sa.ShiftAssignmentId == id, ct);
        }

        public async Task UpdateAsync(ShiftAssignment assignment, CancellationToken ct = default)
        {
            _db.ShiftAssignments.Update(assignment);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<List<ShiftAssignment>> QueryAssignmentsAsync(
            int? employeeId = null,
            DateTime? date = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            int? shiftTypeId = null,
            CancellationToken ct = default)
        {
            var q = _db.ShiftAssignments
                .Include(sa => sa.Shift).ThenInclude(s => s.ShiftType)
                .Include(sa => sa.Employee).ThenInclude(e => e.Position)
                .Include(sa => sa.ApprovedByAccount).ThenInclude(a => a.Employee)
                .AsQueryable();

            if (employeeId.HasValue)
                q = q.Where(sa => sa.EmployeeId == employeeId.Value);

            if (date.HasValue)
            {
                var d = date.Value.Date;
                q = q.Where(sa => sa.Date.Date == d);
            }
            else
            {
                if (dateFrom.HasValue)
                    q = q.Where(sa => sa.Date.Date >= dateFrom.Value.Date);
                if (dateTo.HasValue)
                    q = q.Where(sa => sa.Date.Date <= dateTo.Value.Date);
            }

            if (shiftTypeId.HasValue)
                q = q.Where(sa => sa.Shift.ShiftTypeId == shiftTypeId.Value);

            return await q.AsNoTracking().ToListAsync(ct);
        }


        public async Task<ShiftAssignment?> GetByIdWithDetailsAsync(int id, CancellationToken ct = default)
        {
            return await _db.ShiftAssignments
                .Include(sa => sa.Shift)
                    .ThenInclude(s => s.ShiftType)
                .Include(sa => sa.Employee)
                    .ThenInclude(e => e.Position)
                .AsNoTracking()
                .FirstOrDefaultAsync(sa => sa.ShiftAssignmentId == id, ct);
        }
    }
}
