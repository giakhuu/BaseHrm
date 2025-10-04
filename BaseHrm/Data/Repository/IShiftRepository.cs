using BaseHrm.Data.Models;

namespace BaseHrm.Data.Repository
{
    public interface IShiftRepository
    {
        Task<Shift> AddAsync(Shift shift, CancellationToken ct = default);
        Task UpdateAsync(Shift shift, CancellationToken ct = default);
        Task DeleteAsync(int shiftId, CancellationToken ct = default);
        Task<Shift?> GetByIdAsync(int shiftId, CancellationToken ct = default);
        Task<List<Shift>> GetAllAsync(CancellationToken ct = default);
    }
}
