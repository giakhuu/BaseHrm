using BaseHrm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class RoleWithAccountsDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public List<AccountDto> Accounts { get; set; } = new List<AccountDto>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

        public int AccountCount => Accounts?.Count ?? 0;
    }
}
