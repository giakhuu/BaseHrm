using BaseHrm.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseHrm.Data.Repository
{
    public class AccountPermissionRepository : IAccountPermissionRepository
    {
        private readonly AppDbContext _db;
        public AccountPermissionRepository(AppDbContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

        public async Task<List<AccountPermission>> GetPermissionsForAccountAsync(int accountId, CancellationToken ct = default)
        {
            return await _db.AccountPermissions
                .Where(ap => ap.AccountId == accountId)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<AccountPermission> AddAccountPermissionAsync(AccountPermission ap, CancellationToken ct = default)
        {
            await _db.AccountPermissions.AddAsync(ap, ct);
            return ap;
        }

        public async Task RemoveAccountPermissionAsync(int accountPermissionId, CancellationToken ct = default)
        {
            var ap = await _db.AccountPermissions.FindAsync(new object[] { accountPermissionId }, ct);
            if (ap != null) _db.AccountPermissions.Remove(ap);
        }

        public async Task<Account?> GetAccountWithEmployeeAsync(int accountId, CancellationToken ct = default)
        {
            return await _db.Accounts.Include(a => a.Employee).FirstOrDefaultAsync(a => a.AccountId == accountId, ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _db.SaveChangesAsync(ct);
        }

        public async Task<AccountPermission?> GetAccountPermissionByIdAsync(int accountPermissionId, CancellationToken ct = default)
        {
            return await _db.AccountPermissions.Where(ap => ap.AccountPermissionId == accountPermissionId).FirstOrDefaultAsync(ct);
        }

        public Task UpdateAccountPermissionAsync(AccountPermission ap, CancellationToken ct = default)
        {
            _db.AccountPermissions.Update(ap);
            return Task.CompletedTask;
        }
    }
}
