using BaseHrm.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> SearchEmployeesAsync(
            string? name = null,
            string? email = null,
            string? gender = null,
            DateTime? birthDate = null,
            int? positionId = null,
            int? teamId = null,
            CancellationToken ct = default);
        Task<EmployeeDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(UpdateEmployeeDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<List<EmployeeDto>> GetByTeamAsync(int teamId, CancellationToken ct = default);
    }
}
