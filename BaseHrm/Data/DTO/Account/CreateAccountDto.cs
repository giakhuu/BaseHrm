using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class CreateAccountDto
    {
        public int EmployeeId { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = ""; 
        public string? Role { get; set; } // optional
        public bool IsMaster { get; set; } = false;
    }
}
