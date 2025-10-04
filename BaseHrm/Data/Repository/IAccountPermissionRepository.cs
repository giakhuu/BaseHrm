using BaseHrm.Data.Models;

namespace BaseHrm.Data.Repository
{
    public interface IAccountPermissionRepository
    {
        Task<List<AccountPermission>> GetPermissionsForAccountAsync(int accountId, CancellationToken ct = default);
        Task<AccountPermission?> GetAccountPermissionByIdAsync(int accountPermissionId, CancellationToken ct = default);
        Task<AccountPermission> AddAccountPermissionAsync(AccountPermission ap, CancellationToken ct = default);
        Task RemoveAccountPermissionAsync(int accountPermissionId, CancellationToken ct = default);
        Task UpdateAccountPermissionAsync(AccountPermission ap, CancellationToken ct = default);

        Task<Account?> GetAccountWithEmployeeAsync(int accountId, CancellationToken ct = default); // helper
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
