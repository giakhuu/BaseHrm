using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BaseHrm.Data.DTO
{
    public class UpdateAccountDto
    {
        public int AccountId { get; set; }
        public string? Username { get; set; }   
        public string? NewPassword { get; set; } 
        public string? Role { get; set; }
        public bool? IsMaster { get; set; }
        public bool IsActive { get; set; }
    }
}
