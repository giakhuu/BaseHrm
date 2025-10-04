using BaseHrm.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseHrm.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _db;
        public RoleRepository(AppDbContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

        public async Task<Role?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.Roles
                .Include(r => r.RolePermissions)
                .Include(r => r.AccountRoles)
                .FirstOrDefaultAsync(r => r.RoleId == id, ct);
        }

        public async Task<Role?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            return await _db.Roles
                .Include(r => r.RolePermissions)
                .FirstOrDefaultAsync(r => r.Name == name, ct);
        }

        public async Task<List<Role>> SearchAsync(string? name = null, int? accountId = null, CancellationToken ct = default)
        {
            var q = _db.Roles
                .Include(r => r.AccountRoles)
                    .ThenInclude(ar => ar.Account)
                        .ThenInclude(a => a.Employee)
                            .ThenInclude(e => e.Position)
                .Include(r => r.RolePermissions)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                q = q.Where(r => r.Name.Contains(name));
            }
            if (accountId.HasValue)
            {
                q = q.Where(r => r.AccountRoles.Any(ar => ar.AccountId == accountId.Value));
            }

            return await q.AsNoTracking().ToListAsync(ct);
        }

        public async Task<Role> CreateAsync(Role role, CancellationToken ct = default)
        {
            await _db.Roles.AddAsync(role, ct);
            return role;
        }

        public Task UpdateAsync(Role role, CancellationToken ct = default)
        {
            _db.Roles.Update(role);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Role role, CancellationToken ct = default)
        {
            _db.Roles.Remove(role);
            return Task.CompletedTask;
        }
        public async Task<List<RolePermission>> GetRolePermissionsAsync(int roleId, CancellationToken ct = default)
        {
            return await _db.RolePermissions.Where(rp => rp.RoleId == roleId).AsNoTracking().ToListAsync(ct);
        }

        public async Task<RolePermission?> GetRolePermissionByIdAsync(int rolePermissionId, CancellationToken ct = default)
        {
            return await _db.RolePermissions
                  .FirstOrDefaultAsync(rp => rp.RolePermissionId == rolePermissionId);
        }

        public async Task<RolePermission> AddRolePermissionAsync(RolePermission rp, CancellationToken ct = default)
        {
            await _db.RolePermissions.AddAsync(rp, ct);
            return rp;
        }

        public Task UpdateRolePermissionAsync(RolePermission rp, CancellationToken ct = default)
        {
            _db.RolePermissions.Update(rp);
            return Task.CompletedTask;
        }

        public async Task RemoveRolePermissionAsync(int rolePermissionId, CancellationToken ct = default)
        {
            var rp = await _db.RolePermissions.FindAsync(new object[] { rolePermissionId }, ct);
            if (rp != null) _db.RolePermissions.Remove(rp);
        }

        public async Task AssignRoleToAccountAsync(int accountId, int roleId, CancellationToken ct = default)
        {
            var exists = await _db.AccountRoles.FindAsync(new object[] { accountId, roleId }, ct);
            if (exists == null)
            {
                _db.AccountRoles.Add(new AccountRole { AccountId = accountId, RoleId = roleId });
            }
        }

        public async Task RemoveRoleFromAccountAsync(int accountId, int roleId, CancellationToken ct = default)
        {
            var ar = await _db.AccountRoles.FindAsync(new object[] { accountId, roleId }, ct);
            if (ar != null) _db.AccountRoles.Remove(ar);
        }

        public async Task<List<Role>> GetRolesForAccountAsync(int accountId, CancellationToken ct = default)
        {
            return await _db.AccountRoles
                .Where(ar => ar.AccountId == accountId)
                .Select(ar => ar.Role)
                .Include(r => r.RolePermissions)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _db.SaveChangesAsync(ct);
        }
    }
}
