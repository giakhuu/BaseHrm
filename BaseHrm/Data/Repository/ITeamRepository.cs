using BaseHrm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Repository
{
    public interface ITeamRepository
    {
        Task<Team?> GetByIdAsync(int id);
        Task<List<Team>> SearchAsync(string name = "");
        Task<Team> AddAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(int id);

        // Quản lý thành viên
        Task AddMemberAsync(int teamId, int employeeId, bool isLeader = false);
        Task RemoveMemberAsync(int teamId, int employeeId);
        Task SetLeaderAsync(int teamId, int employeeId);

        // Lấy danh sách nhân viên thuộc các team mà employeeId làm leader
        Task<List<Employee>> GetEmployeesOfTeamsLedByAsync(int leaderEmployeeId);
    }
}
