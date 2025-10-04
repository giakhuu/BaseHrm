using BaseHrm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<Employee>> SearchEmployeesAsync(
                string? name = null,
                string? email = null,
                string? gender = null,
                DateTime? birthDate = null,
                int? positionId = null);
        Task AddAsync(Employee employee, CancellationToken ct = default);
        Task UpdateAsync(Employee employee, CancellationToken ct = default);
        Task DeleteAsync(Employee employee, CancellationToken ct = default);
        Task<List<Employee>> GetByTeamIdAsync(int teamId, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
