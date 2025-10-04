using BaseHrm.Data;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Repository;
using BaseHrm.Data.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security;

namespace BaseHrm.Data.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IRoleRepository _roleRepo;
        private readonly IAccountPermissionRepository _accountPermRepo;
        private readonly AppDbContext _db;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheTtl = TimeSpan.FromMinutes(10);
        private readonly AutoMapper.IMapper _mapper;

        public PermissionService(
            IRoleRepository roleRepo,
            IAccountPermissionRepository accountPermRepo,
            AppDbContext db,
            IMemoryCache cache,
            AutoMapper.IMapper mapper)
        {
            _roleRepo = roleRepo;
            _accountPermRepo = accountPermRepo;
            _db = db;
            _cache = cache;
            _mapper = mapper;
        }

        private string CacheKey(int accountId) => $"perms_{accountId}";

        public async Task<(List<AccountPermission> accountPermissions, List<RolePermission> rolePermissions)> GetEffectivePermissionsAsync(int accountId, CancellationToken ct = default)
        {
            var key = CacheKey(accountId);
            if (_cache.TryGetValue<(List<AccountPermission>, List<RolePermission>)>(key, out var cached))
            {
                return cached;
            }

            var accountPerms = await _accountPermRepo.GetPermissionsForAccountAsync(accountId, ct);

            var roleIds = await _db.AccountRoles.Where(ar => ar.AccountId == accountId)
                                .Select(ar => ar.RoleId).ToListAsync(ct);

            var rolePerms = new List<RolePermission>();
            if (roleIds.Any())
            {
                rolePerms = await _db.RolePermissions.Where(rp => roleIds.Contains(rp.RoleId)).AsNoTracking().ToListAsync(ct);
            }

            var result = (accountPerms, rolePerms);
            _cache.Set(key, result, _cacheTtl);
            return result;
        }

        public async Task<bool> HasPermissionAsync(int accountId, ModuleName module, PermissionAction action, ScopeType scopeType = ScopeType.Global, int? scopeValue = null, CancellationToken ct = default)
        {
            Console.WriteLine($"HasPermissionAsync called: AccountId={accountId}, Module={module}, Action={action}, ScopeType={scopeType}, ScopeValue={scopeValue}");

            if (action == PermissionAction.None) return true;

            var (accountPerms, rolePerms) = await GetEffectivePermissionsAsync(accountId, ct);
            Console.WriteLine("Account permissions:");
            foreach (var p in accountPerms)
                Console.WriteLine($"  {p.Module}-{p.Actions}-{p.ScopeType}-{p.ScopeValue}");
            Console.WriteLine("Role permissions:");
            foreach (var p in rolePerms)
                Console.WriteLine($"  {p.Module}-{p.Actions}-{p.ScopeType}-{p.ScopeValue}");

            // Check direct permission matches
            if (Matches(accountPerms, module, action, scopeType, scopeValue, accountId)) 
            {
                // For OwnTeam with null scope, need to verify user is actually a leader
                if (scopeType == ScopeType.OwnTeam && scopeValue.HasValue)
                {
                    var hasOwnTeamWithNullScope = HasOwnTeamPermissionWithNullScope(accountPerms, module, action) || 
                                                  HasOwnTeamPermissionWithNullScope(rolePerms, module, action);
                    
                    if (hasOwnTeamWithNullScope)
                    {
                        var employeeId = await GetEmployeeIdForAccountAsync(accountId, ct);
                        if (employeeId.HasValue)
                        {
                            var isLeader = await _db.TeamMembers.AnyAsync(tm => tm.TeamId == scopeValue.Value && tm.EmployeeId == employeeId.Value && tm.IsLeader, ct);
                            Console.WriteLine($"  User is leader of team {scopeValue.Value}: {isLeader}");
                            if (!isLeader) return false; // User has OwnTeam permission but is not leader of this specific team
                        }
                    }
                }
                return true;
            }

            if (Matches(rolePerms, module, action, scopeType, scopeValue, accountId))
            {
                // For OwnTeam with null scope, need to verify user is actually a leader
                if (scopeType == ScopeType.OwnTeam && scopeValue.HasValue)
                {
                    var hasOwnTeamWithNullScope = HasOwnTeamPermissionWithNullScope(accountPerms, module, action) || 
                                                  HasOwnTeamPermissionWithNullScope(rolePerms, module, action);
                    
                    if (hasOwnTeamWithNullScope)
                    {
                        var employeeId = await GetEmployeeIdForAccountAsync(accountId, ct);
                        if (employeeId.HasValue)
                        {
                            var isLeader = await _db.TeamMembers.AnyAsync(tm => tm.TeamId == scopeValue.Value && tm.EmployeeId == employeeId.Value && tm.IsLeader, ct);
                            Console.WriteLine($"  User is leader of team {scopeValue.Value}: {isLeader}");
                            if (!isLeader) return false; // User has OwnTeam permission but is not leader of this specific team
                        }
                    }
                }
                return true;
            }

            // Additional logic for OwnTeam scope
            if (scopeType == ScopeType.OwnTeam)
            {
                if (scopeValue.HasValue)
                {
                    var employeeId = await GetEmployeeIdForAccountAsync(accountId, ct);
                    if (employeeId.HasValue)
                    {
                        var isLeader = await _db.TeamMembers.AnyAsync(tm => tm.TeamId == scopeValue.Value && tm.EmployeeId == employeeId.Value && tm.IsLeader, ct);
                        Console.WriteLine($"  Checking if user is leader of team {scopeValue.Value}: {isLeader}");
                        if (isLeader)
                        {
                            if (Matches(accountPerms, module, action, ScopeType.Team, scopeValue, accountId)) return true;
                            if (Matches(rolePerms, module, action, ScopeType.Team, scopeValue, accountId)) return true;
                        }
                    }
                }
            }

            if (scopeType == ScopeType.Self)
            {
                var employeeId = await GetEmployeeIdForAccountAsync(accountId, ct);
                if (employeeId.HasValue && scopeValue.HasValue && employeeId.Value == scopeValue.Value)
                {
                    if (Matches(accountPerms, module, action, ScopeType.Self, null, accountId)) return true;
                    if (Matches(rolePerms, module, action, ScopeType.Self, null, accountId)) return true;
                    if (Matches(accountPerms, module, action, ScopeType.Global, null, accountId)) return true;
                    if (Matches(rolePerms, module, action, ScopeType.Global, null, accountId)) return true;
                }
            }

            Console.WriteLine($"  No matching permission found");
            return false;
        }

        private bool HasOwnTeamPermissionWithNullScope<T>(IEnumerable<T> permissions, ModuleName module, PermissionAction action)
        {
            foreach (var p in permissions)
            {
                ModuleName pModule;
                PermissionAction pActions;
                ScopeType pScope;
                int? pScopeVal;

                if (p is AccountPermission ap)
                {
                    pModule = ap.Module;
                    pActions = ap.Actions;
                    pScope = ap.ScopeType;
                    pScopeVal = ap.ScopeValue;
                }
                else if (p is RolePermission rp)
                {
                    pModule = rp.Module;
                    pActions = rp.Actions;
                    pScope = rp.ScopeType;
                    pScopeVal = rp.ScopeValue;
                }
                else continue;

                if (pModule == module && (pActions & action) == action && pScope == ScopeType.OwnTeam && pScopeVal == null)
                {
                    return true;
                }
            }
            return false;
        }

        private bool Matches<T>(IEnumerable<T> perms, ModuleName module, PermissionAction action, ScopeType requiredScope, int? requiredScopeValue, int accountId)
        {
            foreach (var p in perms)
            {
                ModuleName pModule;
                PermissionAction pActions;
                ScopeType pScope;
                int? pScopeVal;

                if (p is AccountPermission ap)
                {
                    pModule = ap.Module;
                    pActions = ap.Actions;
                    pScope = ap.ScopeType;
                    pScopeVal = ap.ScopeValue;
                }
                else if (p is RolePermission rp)
                {
                    pModule = rp.Module;
                    pActions = rp.Actions;
                    pScope = rp.ScopeType;
                    pScopeVal = rp.ScopeValue;
                }
                else continue;

                if (pModule != module) continue;
                if ((pActions & action) != action) continue; 

                // Global permission always matches
                if (pScope == ScopeType.Global) return true;

                // Exact scope and value match
                if (pScope == requiredScope)
                {
                    if (pScopeVal == null && requiredScopeValue == null) return true;
                    if (pScopeVal != null && requiredScopeValue != null && pScopeVal == requiredScopeValue) return true;
                    
                    // Special case: OwnTeam with null ScopeValue means permission on ALL teams where user is leader
                    if (pScope == ScopeType.OwnTeam && pScopeVal == null && requiredScopeValue != null)
                    {
                        Console.WriteLine($"  Found OwnTeam permission with null scope - checking if user is leader of team {requiredScopeValue}");
                        return true; // Will be validated by the calling logic
                    }
                }

                // Team permission can satisfy OwnTeam requirement
                if (pScope == ScopeType.Team && requiredScope == ScopeType.OwnTeam && requiredScopeValue != null)
                {
                    if (pScopeVal == requiredScopeValue) return true;
                }

                // Self permission matches Self scope
                if (pScope == ScopeType.Self && requiredScope == ScopeType.Self) return true;
            }
            return false;
        }

        private async Task<int?> GetEmployeeIdForAccountAsync(int accountId, CancellationToken ct = default)
        {
            var acc = await _accountPermRepo.GetAccountWithEmployeeAsync(accountId, ct);
            return acc?.EmployeeId;
        }

        public async Task<List<RoleWithAccountsDto>> SearchRolesAsync(string? name = null, int? accountId = null, CancellationToken ct = default)
        {
            var roles = await _roleRepo.SearchAsync(name: name, accountId: accountId, ct: ct); 
            
            var dtos = _mapper.Map<List<RoleWithAccountsDto>>(roles);
            foreach (var r in dtos)
                r.Accounts = r.Accounts.OrderBy(a => a.EmployeeFullName ?? a.Username).ToList();

            return dtos;
        }

        public async Task<Role> CreateRoleAsync(Role role, CancellationToken ct = default)
        {
            var existing = await _roleRepo.GetByNameAsync(role.Name, ct);
            if (existing != null) throw new InvalidOperationException("Role name already exists.");

            var created = await _roleRepo.CreateAsync(role, ct);
            await _roleRepo.SaveChangesAsync(ct);
            await InvalidateAllCacheAsync();
            return created;
        }

        public async Task UpdateRoleAsync(Role role, CancellationToken ct = default)
        {
            var existing = await _roleRepo.GetByIdAsync(role.RoleId, ct) ?? throw new InvalidOperationException("Role not found.");
            existing.Name = role.Name;
            existing.Description = role.Description;
            await _roleRepo.UpdateAsync(existing, ct);
            await _roleRepo.SaveChangesAsync(ct);
            await InvalidateAllCacheAsync();
        }

        public async Task DeleteRoleAsync(int roleId, CancellationToken ct = default)
        {
            var existing = await _roleRepo.GetByIdAsync(roleId, ct) ?? throw new InvalidOperationException("Role not found.");
            await _roleRepo.DeleteAsync(existing, ct);
            await _roleRepo.SaveChangesAsync(ct);
            await InvalidateAllCacheAsync();
        }
        public async Task AddAndUpdateRolePermission(List<RolePermission> rolePermissions, CancellationToken ct = default)
        {
            foreach (var rp in rolePermissions)
            {
                if (rp.RolePermissionId == 0)
                {
                    await AddRolePermissionAsync(rp, ct);
                }
                else
                {
                    await UpdateRolePermissionAsync(rp, ct);
                }
            }
        }
        public async Task<RolePermission> AddRolePermissionAsync(RolePermission rp, CancellationToken ct = default)
        {
            var added = await _roleRepo.AddRolePermissionAsync(rp, ct);
            await _roleRepo.SaveChangesAsync(ct);
            await InvalidateAllCacheAsync();
            return added;
        }
        public async Task UpdateRolePermissionAsync(RolePermission rp, CancellationToken ct = default)
        {
            var existing = await _roleRepo.GetRolePermissionByIdAsync(rp.RolePermissionId, ct);
            Helper.PrintJson(existing);
            existing.Module = rp.Module;
            existing.Actions = rp.Actions;
            existing.ScopeType = rp.ScopeType;
            existing.ScopeValue = rp.ScopeValue;

            await _roleRepo.UpdateRolePermissionAsync(existing, ct);
            await _roleRepo.SaveChangesAsync(ct);
            await InvalidateAllCacheAsync();
        }
        public async Task RemoveRolePermissionAsync(int rolePermissionId, CancellationToken ct = default)
        {
            await _roleRepo.RemoveRolePermissionAsync(rolePermissionId, ct);
            await _roleRepo.SaveChangesAsync(ct);
            await InvalidateAllCacheAsync();
        }

        public async Task AssignRoleToAccountAsync(int accountId, int roleId, CancellationToken ct = default)
        {
            await _roleRepo.AssignRoleToAccountAsync(accountId, roleId, ct);
            await _roleRepo.SaveChangesAsync(ct);
            await InvalidateCacheForAccountAsync(accountId);
        }

        public async Task RemoveRoleFromAccountAsync(int accountId, int roleId, CancellationToken ct = default)
        {
            await _roleRepo.RemoveRoleFromAccountAsync(accountId, roleId, ct);
            await _roleRepo.SaveChangesAsync(ct);
            await InvalidateCacheForAccountAsync(accountId);
        }

        public async Task<AccountPermission> AddAccountPermissionAsync(AccountPermission ap, CancellationToken ct = default)
        {
            var added = await _accountPermRepo.AddAccountPermissionAsync(ap, ct);
            await _accountPermRepo.SaveChangesAsync(ct);
            await InvalidateCacheForAccountAsync(ap.AccountId);
            return added;
        }

        public async Task RemoveAccountPermissionAsync(int accountPermissionId, CancellationToken ct = default)
        {
            // we need accountId to invalidate cache; fetch it
            var ap = await _db.AccountPermissions.FindAsync(new object[] { accountPermissionId }, ct);
            var accountId = ap?.AccountId;
            await _accountPermRepo.RemoveAccountPermissionAsync(accountPermissionId, ct);
            await _accountPermRepo.SaveChangesAsync(ct);
            if (accountId.HasValue) await InvalidateCacheForAccountAsync(accountId.Value);
        }

        public Task InvalidateCacheForAccountAsync(int accountId)
        {
            _cache.Remove(CacheKey(accountId));
            return Task.CompletedTask;
        }

        public Task InvalidateAllCacheAsync()
        {
            if (_cache is MemoryCache memCache)
            {
                memCache.Compact(1.0); 
            }
            return Task.CompletedTask;
        }

        public async Task AddAndUpdateAccountPermission(List<AccountPermission> accountPermissions, CancellationToken ct = default)
        {
            foreach (var ap in accountPermissions)
            {
                if (ap.AccountPermissionId == 0)
                {
                    await AddAccountPermissionAsync(ap, ct);
                }
                else
                {
                    await UpdateAccountPermission(ap, ct);
                }
            }
        }

        public async Task UpdateAccountPermission(AccountPermission ap, CancellationToken ct = default)
        {
            var existing = await _accountPermRepo.GetAccountPermissionByIdAsync(ap.AccountPermissionId, ct);
            Helper.PrintJson(existing);
            existing.Module = ap.Module;
            existing.Actions = ap.Actions;
            existing.ScopeType = ap.ScopeType;
            existing.ScopeValue = ap.ScopeValue;

            await _accountPermRepo.UpdateAccountPermissionAsync(existing, ct);
            await _accountPermRepo.SaveChangesAsync(ct);
            await InvalidateAllCacheAsync();
        }

        /// <summary>
        /// Kiểm tra xem user có bất kỳ quyền nào trên module hay không (bất kể ScopeType)
        /// Dùng để hiển thị/ẩn các nút menu
        /// </summary>
        public async Task<bool> HasModuleAccessAsync(int accountId, ModuleName module, PermissionAction action = PermissionAction.View, CancellationToken ct = default)
        {
            Console.WriteLine($"HasModuleAccessAsync called: AccountId={accountId}, Module={module}, Action={action}");

            if (action == PermissionAction.None) return true;

            var (accountPerms, rolePerms) = await GetEffectivePermissionsAsync(accountId, ct);
            
            // Kiểm tra account permissions với bất kỳ scope nào
            if (HasModulePermission(accountPerms, module, action))
            {
                Console.WriteLine($"Found module access in account permissions");
                return true;
            }

            // Kiểm tra role permissions với bất kỳ scope nào
            if (HasModulePermission(rolePerms, module, action))
            {
                Console.WriteLine($"Found module access in role permissions");
                return true;
            }

            Console.WriteLine($"No module access found for {module}");
            return false;
        }

        /// <summary>
        /// Helper method để kiểm tra quyền trên module với bất kỳ scope nào
        /// </summary>
        private bool HasModulePermission<T>(IEnumerable<T> permissions, ModuleName module, PermissionAction action)
        {
            foreach (var p in permissions)
            {
                ModuleName pModule;
                PermissionAction pActions;

                if (p is AccountPermission ap)
                {
                    pModule = ap.Module;
                    pActions = ap.Actions;
                }
                else if (p is RolePermission rp)
                {
                    pModule = rp.Module;
                    pActions = rp.Actions;
                }
                else continue;

                // Chỉ kiểm tra module và action, bỏ qua ScopeType
                if (pModule == module && (pActions & action) == action)
                {
                    Console.WriteLine($"  Found permission: Module={pModule}, Actions={pActions}");
                    return true;
                }
            }

            return false;
        }
    }
}
