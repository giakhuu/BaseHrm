using BaseHrm.Data.DTO;

namespace BaseHrm.Data.Service
{
    public interface IShiftService
    {
        Task<ShiftTypeDto> CreateShiftTypeAsync(ShiftTypeDto dto, CancellationToken ct = default);
        Task<bool> UpdateShiftTypeAsync(ShiftTypeDto dto, CancellationToken ct = default);
        Task<bool> DeleteShiftTypeAsync(int id, CancellationToken ct = default);
        Task<List<ShiftTypeDto>> GetAllShiftTypesAsync(CancellationToken ct = default);

        Task<ShiftDto> CreateShiftAsync(ShiftDto dto, CancellationToken ct = default);
        Task<bool> UpdateShiftAsync(ShiftDto dto, CancellationToken ct = default);
        Task<bool> DeleteShiftAsync(int id, CancellationToken ct = default);
        Task<List<ShiftDto>> GetAllShiftsAsync(CancellationToken ct = default);
        Task<ShiftDto?> GetShiftByIdAsync(int id, CancellationToken ct = default);

        Task<ShiftAssignmentDto> AssignShiftAsync(ShiftAssignmentDto dto, CancellationToken ct = default);
        Task<bool> RemoveAssignmentAsync(int shiftAssignmentId, CancellationToken ct = default);
        Task<bool> UpdateAssignmentAsync(ShiftAssignmentDto dto, CancellationToken ct = default);
        Task<List<ShiftAssignmentDto>> QueryAssignmentsAsync(
            int? employeeId = null,
            int? teamId = null,
            DateTime? date = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            int? shiftTypeId = null,
            CancellationToken ct = default);
        Task<ShiftAssignmentDto?> GetAssignmentByIdAsync(int id, CancellationToken ct = default);
        Task<ShiftAssignmentDto?> getTodayShiftAssignmentAsync();
    }
}
