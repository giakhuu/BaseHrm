using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace BaseHrm.Data.Repository
{
    public class ShiftTypeRepository : IShiftTypeRepository
    {
        private readonly AppDbContext _db;
        public ShiftTypeRepository(AppDbContext db) => _db = db;

        public async Task<ShiftType> AddAsync(ShiftType entity, CancellationToken ct = default)
        {
            await _db.ShiftTypes.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
            return entity;
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var ent = await _db.ShiftTypes.FindAsync(new object[] { id }, ct);
            if (ent != null)
            {
                _db.ShiftTypes.Remove(ent);
                await _db.SaveChangesAsync(ct);
            }
        }

        public async Task<List<ShiftType>> GetAllAsync(CancellationToken ct = default)
        {
            return await _db.ShiftTypes.AsNoTracking().ToListAsync(ct);
        }

        public async Task<ShiftType?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.ShiftTypes.FirstOrDefaultAsync(x => x.ShiftTypeId == id, ct);
        }

        public async Task UpdateAsync(ShiftType entity, CancellationToken ct = default)
        {
            _db.ShiftTypes.Update(entity);
            await _db.SaveChangesAsync(ct);
        }
    }
}
