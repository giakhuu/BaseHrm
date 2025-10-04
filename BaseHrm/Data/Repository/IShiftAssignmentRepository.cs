using BaseHrm.Data.Models;

namespace BaseHrm.Data.Repository
{
    public interface IShiftAssignmentRepository
    {
        Task<ShiftAssignment> AddAsync(ShiftAssignment assignment, CancellationToken ct = default);
        Task UpdateAsync(ShiftAssignment assignment, CancellationToken ct = default);
        Task DeleteAsync(int shiftAssignmentId, CancellationToken ct = default);
        Task<ShiftAssignment?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<ShiftAssignment>> QueryAssignmentsAsync(
            int? employeeId = null,
            DateTime? date = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            int? shiftTypeId = null,
            CancellationToken ct = default);
        Task<ShiftAssignment?> GetByIdWithDetailsAsync(int id, CancellationToken ct = default);
    }
}
