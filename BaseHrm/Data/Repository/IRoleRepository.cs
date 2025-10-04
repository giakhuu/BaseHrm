using BaseHrm.Data.Models;

namespace BaseHrm.Data.Repository
{
    public interface IRoleRepository
    {
        Task<Role?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Role?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<List<Role>> SearchAsync(string? name = null, int? accountId = null, CancellationToken ct = default);

        Task<Role> CreateAsync(Role role, CancellationToken ct = default);
        Task UpdateAsync(Role role, CancellationToken ct = default);
        Task DeleteAsync(Role role, CancellationToken ct = default);

        Task<List<RolePermission>> GetRolePermissionsAsync(int roleId, CancellationToken ct = default);
        Task<RolePermission?> GetRolePermissionByIdAsync(int rolePermissionId, CancellationToken ct = default);
        Task<RolePermission> AddRolePermissionAsync(RolePermission rp, CancellationToken ct = default);
        Task UpdateRolePermissionAsync(RolePermission rp, CancellationToken ct = default);
        Task RemoveRolePermissionAsync(int rolePermissionId, CancellationToken ct = default);

        Task AssignRoleToAccountAsync(int accountId, int roleId, CancellationToken ct = default);
        Task RemoveRoleFromAccountAsync(int accountId, int roleId, CancellationToken ct = default);
        Task<List<Role>> GetRolesForAccountAsync(int accountId, CancellationToken ct = default);

        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
