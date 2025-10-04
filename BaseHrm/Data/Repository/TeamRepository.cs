using BaseHrm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            return await _context.Teams
                .Include(t => t.Leader)
                .Include(t => t.Members)
                    .ThenInclude(m => m.Employee)
                .FirstOrDefaultAsync(t => t.TeamId == id);
        }

        public async Task<List<Team>> SearchAsync(string name = "")
        {
            var query = _context.Teams
                .Include(t => t.Leader)
                .Include(t => t.Members).ThenInclude(m => m.Employee)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(t => t.Name.Contains(name));

            return await query.ToListAsync();
        }

        public async Task<Team> AddAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task UpdateAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddMemberAsync(int teamId, int employeeId, bool isLeader = false)
        {
            var exists = await _context.TeamMembers
                .AnyAsync(m => m.TeamId == teamId && m.EmployeeId == employeeId);

            if (!exists)
            {
                var member = new TeamMember
                {
                    TeamId = teamId,
                    EmployeeId = employeeId,
                    IsLeader = isLeader,
                    JoinedAt = DateTime.UtcNow
                };
                _context.TeamMembers.Add(member);

                if (isLeader)
                {
                    var team = await _context.Teams.FindAsync(teamId);
                    if (team != null)
                        team.LeaderId = employeeId;
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveMemberAsync(int teamId, int employeeId)
        {
            var member = await _context.TeamMembers
                .FirstOrDefaultAsync(m => m.TeamId == teamId && m.EmployeeId == employeeId);

            if (member != null)
            {
                _context.TeamMembers.Remove(member);

                var team = await _context.Teams.FindAsync(teamId);
                if (team != null && team.LeaderId == employeeId)
                {
                    team.LeaderId = null;
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task SetLeaderAsync(int teamId, int employeeId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team == null) throw new Exception("Team not found");

            var oldLeader = await _context.TeamMembers
                .FirstOrDefaultAsync(m => m.TeamId == teamId && m.IsLeader);

            if (oldLeader != null)
                oldLeader.IsLeader = false;

            var member = await _context.TeamMembers
                .FirstOrDefaultAsync(m => m.TeamId == teamId && m.EmployeeId == employeeId);

            if (member == null)
            {
                member = new TeamMember
                {
                    TeamId = teamId,
                    EmployeeId = employeeId,
                    IsLeader = true,
                    JoinedAt = DateTime.UtcNow
                };
                _context.TeamMembers.Add(member);
            }
            else
            {
                member.IsLeader = true;
            }

            team.LeaderId = employeeId;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeesOfTeamsLedByAsync(int leaderEmployeeId)
        {
            // Lấy các team mà leaderId = leaderEmployeeId
            var teamIds = await _context.Teams
                .Where(t => t.LeaderId == leaderEmployeeId)
                .Select(t => t.TeamId)
                .ToListAsync();

            // Lấy các thành viên của các team đó
            var employees = await _context.TeamMembers
                .Where(tm => teamIds.Contains(tm.TeamId))
                .Include(tm => tm.Employee)
                .Select(tm => tm.Employee)
                .Where(e => e != null)
                .Distinct()
                .ToListAsync();

            return employees!;
        }
    }
}
