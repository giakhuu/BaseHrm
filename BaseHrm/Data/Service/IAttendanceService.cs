using BaseHrm.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public interface IAttendanceService
    {
        Task<AttendanceRecordDto?> GetByIdAsync(int id, CancellationToken ct = default);

        Task<List<AttendanceRecordDto>> QueryAsync(
            int? employeeId = null,
            int? shiftAssignmentId = null,
            int? shiftTypeId = null,
            DateTime? date = null,
            DateTime? dateFrom = null,
            DateTime? dateTo = null,
            bool? isOvertime = null,
            int? teamId = null,
            CancellationToken ct = default);

        Task<AttendanceRecordDto> CreateAsync(AttendanceRecordDto dto, CancellationToken ct = default);

        Task<bool> UpdateAsync(AttendanceRecordDto dto, CancellationToken ct = default);

        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}

