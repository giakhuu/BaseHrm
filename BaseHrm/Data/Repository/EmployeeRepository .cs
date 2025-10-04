using BaseHrm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;
        public EmployeeRepository(AppDbContext db) => _db = db;

        public async Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.Employees
                .Include(e => e.TeamMemberships)
                    .ThenInclude(tm => tm.Team)
                .Include(e => e.AttendanceRecords)
                .Include(e => e.ShiftAssignments)
                .Include(e => e.Position)
                .FirstOrDefaultAsync(e => e.EmployeeId == id, ct);
        }
        public async Task<List<Employee>> SearchEmployeesAsync(
            string? name = null,
            string? email = null,
            string? gender = null,
            DateTime? birthDate = null,
            int? positionId = null)
        {
            var query = _db.Employees
                .Include(e => e.Position) 
                .Include(e => e.TeamMemberships)
                    .ThenInclude(tm => tm.Team)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e =>
                    e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(e => e.Email.Contains(email));
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(e => e.Gender == gender);
            }

            if (birthDate.HasValue)
            {
                query = query.Where(e => e.DateOfBirth == birthDate.Value);
            }

            if (positionId.HasValue)
            {
                query = query.Where(e => e.PositionId == positionId.Value);
            }

            return await query.ToListAsync();
        }

        public async Task AddAsync(Employee employee, CancellationToken ct = default)
        {
            await _db.Employees.AddAsync(employee, ct);
        }

        public Task UpdateAsync(Employee employee, CancellationToken ct = default)
        {
            _db.Employees.Update(employee);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Employee employee, CancellationToken ct = default)
        {
            _db.Employees.Remove(employee);
            return Task.CompletedTask;
        }

        public async Task<List<Employee>> GetByTeamIdAsync(int teamId, CancellationToken ct = default)
        {
            return await _db.TeamMembers
                .Where(tm => tm.TeamId == teamId)
                .Include(tm => tm.Employee)
                .Select(tm => tm.Employee!)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _db.SaveChangesAsync(ct);
        }
    }
}
