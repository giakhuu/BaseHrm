using BaseHrm.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
        public ICollection<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
    }

    public class RolePermission
    {
        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public ModuleName Module { get; set; }
        public PermissionAction Actions { get; set; }
        public ScopeType ScopeType { get; set; } = ScopeType.Global;
        public int? ScopeValue { get; set; } 
    }

    public class AccountRole
    {
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }

    public class AccountPermission
    {
        public int AccountPermissionId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public ModuleName Module { get; set; }
        public PermissionAction Actions { get; set; }
        public ScopeType ScopeType { get; set; } = ScopeType.Global;
        public int? ScopeValue { get; set; }
    }

}
