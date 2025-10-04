using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";

        public ICollection<AccountRole> AccountRoles { get; set; } = new List<AccountRole>();
        public ICollection<AccountPermission> AccountPermissions { get; set; } = new List<AccountPermission>();


        public bool IsMaster { get; set; } = false;
        public DateTime? LastLogin { get; set; }

    }
}
