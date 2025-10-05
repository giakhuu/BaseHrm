using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class AccountDto
    {
        public int AccountId { get; set; }

        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
        public bool IsMaster { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }

        public int EmployeeId { get; set; }               // "Mã"
        public string? EmployeeFullName { get; set; }     // FullName
        public string? EmployeePhone { get; set; }        // Phone
        public string? EmployeePositionName { get; set; } // Position name
        public string? EmployeeEmail { get; set; }        // Email
    }
}

