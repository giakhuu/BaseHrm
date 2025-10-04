using BaseHrm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AppDbContext _db;
        public PositionRepository(AppDbContext db) => _db = db;

        public async Task<List<Position>> GetAllAsync(CancellationToken ct = default)
        {
            return await _db.Positions.Include(p => p.Employees).AsNoTracking().ToListAsync(ct);
        }

        public async Task<Position?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.Positions.Include(p => p.Employees)
                .FirstOrDefaultAsync(p => p.PositionId == id, ct);
        }

        public async Task AddAsync(Position pos, CancellationToken ct = default)
        {
            await _db.Positions.AddAsync(pos, ct);
        }

        public Task UpdateAsync(Position pos, CancellationToken ct = default)
        {
            _db.Positions.Update(pos);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Position pos, CancellationToken ct = default)
        {
            _db.Positions.Remove(pos);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _db.SaveChangesAsync(ct);
        }
    }
}
