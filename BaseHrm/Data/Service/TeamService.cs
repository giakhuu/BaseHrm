using AutoMapper;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Service
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repo;
        private readonly IMapper _mapper;
        public TeamService(ITeamRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TeamDto?> GetByIdAsync(int id)
        {
            var team = await _repo.GetByIdAsync(id);
            return team == null ? null : _mapper.Map<TeamDto>(team);
        }

        public async Task<List<TeamDto>> SearchAsync(string name = "")
        {
            var teams = await _repo.SearchAsync(name);
            return _mapper.Map<List<TeamDto>>(teams);
        }

        public async Task<TeamDto> CreateAsync(string name, int? leaderId = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Hãy điền tên team", nameof(name));

            var existing = await _repo.SearchAsync(name);
            if (existing.Any(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Team đã tồn tại hãy đổi tên khác.");

            var team = new Team
            {
                Name = name,
                LeaderId = leaderId
            };
            await _repo.AddAsync(team);
            return _mapper.Map<TeamDto>(team);
        }



        public async Task UpdateAsync(int id, string name, int? leaderId = null)
        {
            var team = await _repo.GetByIdAsync(id);
            if (team == null) throw new Exception("Không tìm thấy team");

            team.Name = name;
            team.LeaderId = leaderId;
            await _repo.UpdateAsync(team);
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task AddMemberAsync(int teamId, int employeeId, bool isLeader = false)
            => await _repo.AddMemberAsync(teamId, employeeId, isLeader);

        public async Task RemoveMemberAsync(int teamId, int employeeId)
            => await _repo.RemoveMemberAsync(teamId, employeeId);

        public async Task SetLeaderAsync(int teamId, int employeeId)
            => await _repo.SetLeaderAsync(teamId, employeeId);

        public async Task<List<EmployeeDto>> GetEmployeesOfTeamsLedByAsync(int leaderEmployeeId)
        {
            var employees = await _repo.GetEmployeesOfTeamsLedByAsync(leaderEmployeeId);
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

    }
}
