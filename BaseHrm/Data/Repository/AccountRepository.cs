using BaseHrm.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseHrm.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _db;
        public AccountRepository(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Account?> GetByUsernameAsync(string username, CancellationToken ct = default)
        {
            return await _db.Accounts.Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.Username == username, ct);
        }

        public async Task<Account?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.Accounts.Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.AccountId == id, ct);
        }

        public async Task AddAsync(Account account, CancellationToken ct = default)
        {
            await _db.Accounts.AddAsync(account, ct);
        }

        public Task UpdateAsync(Account account, CancellationToken ct = default)
        {
            _db.Accounts.Update(account);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Account account, CancellationToken ct = default)
        {
            _db.Accounts.Remove(account);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _db.SaveChangesAsync(ct);
        }

        public async Task<List<Account>> SearchAsync(string? username = null, string? role = null, bool? isMaster = null, int? employeeId = null, CancellationToken ct = default)
        {
            var q = _db.Accounts.Include(a => a.Employee).ThenInclude(e => e.Position).AsQueryable();

            if (!string.IsNullOrWhiteSpace(username))
                q = q.Where(a => a.Username.Contains(username));

           

            if (isMaster.HasValue)
                q = q.Where(a => a.IsMaster == isMaster.Value);

            if (employeeId.HasValue)
                q = q.Where(a => a.EmployeeId == employeeId.Value);

            return await q.AsNoTracking().ToListAsync(ct);
        }

        public async Task<Account?> GetMasterAccountAsync(CancellationToken ct = default)
        {
            return await _db.Accounts.Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.IsMaster, ct);
        }
    }
}
