using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;

namespace BaseHrm.Data.Service
{
    public interface IPermissionService
    {
        Task<bool> HasPermissionAsync(int accountId, ModuleName module, PermissionAction action, ScopeType scopeType = ScopeType.Global, int? scopeValue = null, CancellationToken ct = default);

        /// <summary>
        /// Kiểm tra xem user có bất kỳ quyền nào trên module hay không (bất kể ScopeType)
        /// Dùng để hiển thị/ẩn các nút menu
        /// </summary>
        Task<bool> HasModuleAccessAsync(int accountId, ModuleName module, PermissionAction action = PermissionAction.View, CancellationToken ct = default);

        Task<(List<AccountPermission> accountPermissions, List<RolePermission> rolePermissions)> GetEffectivePermissionsAsync(int accountId, CancellationToken ct = default);

        Task<List<RoleWithAccountsDto>> SearchRolesAsync(string? name = null, int? accountId = null, CancellationToken ct = default);
        Task<Role> CreateRoleAsync(Role role, CancellationToken ct = default);
        Task UpdateRoleAsync(Role role, CancellationToken ct = default);
        Task DeleteRoleAsync(int roleId, CancellationToken ct = default);

        Task<RolePermission> AddRolePermissionAsync(RolePermission rp, CancellationToken ct = default);
        Task AddAndUpdateRolePermission(List<RolePermission> rolePermissions, CancellationToken ct = default);
        Task RemoveRolePermissionAsync(int rolePermissionId, CancellationToken ct = default);

        Task AssignRoleToAccountAsync(int accountId, int roleId, CancellationToken ct = default);
        Task RemoveRoleFromAccountAsync(int accountId, int roleId, CancellationToken ct = default);

        Task<AccountPermission> AddAccountPermissionAsync(AccountPermission ap, CancellationToken ct = default);
        Task AddAndUpdateAccountPermission(List<AccountPermission> accountPermissions, CancellationToken ct = default);
        Task UpdateAccountPermission(AccountPermission ap, CancellationToken ct = default);
        Task RemoveAccountPermissionAsync(int accountPermissionId, CancellationToken ct = default);

        Task InvalidateCacheForAccountAsync(int accountId);
        Task InvalidateAllCacheAsync();
    }
}
