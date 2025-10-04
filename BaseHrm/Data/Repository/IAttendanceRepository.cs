using BaseHrm.Data.Models;

namespace BaseHrm.Data.Repository
{
    public interface IAttendanceRepository
    {
        Task<AttendanceRecord?> GetByIdAsync(int id, CancellationToken ct = default);

        Task<List<AttendanceRecord>> QueryAsync(
            int? employeeId = null,
            int? shiftAssignmentId = null,
            int? shiftTypeId = null,
            DateTime? date = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            bool? isOvertime = null,
            CancellationToken ct = default);

        Task<AttendanceRecord> AddAsync(AttendanceRecord entity, CancellationToken ct = default);
        Task UpdateAsync(AttendanceRecord entity, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
