using BaseHrm.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public interface ITeamService
    {
        Task<TeamDto?> GetByIdAsync(int id);
        Task<List<TeamDto>> SearchAsync(string name = "");
        Task<TeamDto> CreateAsync(string name, int? leaderId = null);
        Task UpdateAsync(int id, string name, int? leaderId = null);
        Task DeleteAsync(int id);

        Task AddMemberAsync(int teamId, int employeeId, bool isLeader = false);
        Task RemoveMemberAsync(int teamId, int employeeId);
        Task SetLeaderAsync(int teamId, int employeeId);
        Task<List<EmployeeDto>> GetEmployeesOfTeamsLedByAsync(int leaderEmployeeId);
    }
}
