using BaseHrm.Data.Models;

namespace BaseHrm.Data.Repository
{
    public interface IShiftTypeRepository
    {
        Task<ShiftType> AddAsync(ShiftType entity, CancellationToken ct = default);
        Task UpdateAsync(ShiftType entity, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
        Task<ShiftType?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<ShiftType>> GetAllAsync(CancellationToken ct = default);
    }
}
