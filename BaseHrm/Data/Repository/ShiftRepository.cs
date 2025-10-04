using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace BaseHrm.Data.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext _db;
        public ShiftRepository(AppDbContext db) => _db = db;

        public async Task<Shift> AddAsync(Shift shift, CancellationToken ct = default)
        {
            await _db.Shifts.AddAsync(shift, ct);
            await _db.SaveChangesAsync(ct);
            return shift;
        }

        public async Task DeleteAsync(int shiftId, CancellationToken ct = default)
        {
            var ent = await _db.Shifts.FindAsync(new object[] { shiftId }, ct);
            if (ent != null)
            {
                _db.Shifts.Remove(ent);
                await _db.SaveChangesAsync(ct);
            }
        }

        public async Task<List<Shift>> GetAllAsync(CancellationToken ct = default)
        {
            return await _db.Shifts.Include(s => s.ShiftType).AsNoTracking().ToListAsync(ct);
        }

        public async Task<Shift?> GetByIdAsync(int shiftId, CancellationToken ct = default)
        {
            return await _db.Shifts.Include(s => s.ShiftType)
                .FirstOrDefaultAsync(s => s.ShiftId == shiftId, ct);
        }

        public async Task UpdateAsync(Shift shift, CancellationToken ct = default)
        {
            _db.Shifts.Update(shift);
            await _db.SaveChangesAsync(ct);
        }
    }
}
