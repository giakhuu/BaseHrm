using BaseHrm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Repository
{
    public interface IPositionRepository
    {
        Task<List<Position>> GetAllAsync(CancellationToken ct = default);
        Task<Position?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(Position pos, CancellationToken ct = default);
        Task UpdateAsync(Position pos, CancellationToken ct = default);
        Task DeleteAsync(Position pos, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
