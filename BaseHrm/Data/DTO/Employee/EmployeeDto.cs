using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";

        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        public decimal MaxHoursPerDay { get; set; }
        public decimal MaxHoursPerMonth { get; set; }

        public decimal TotalHoursThisMonth { get; set; }
        public decimal TotalHoursToday { get; set; }
        public int?  PositionId { get; set; } = null;
        public string? Position { get; set; } = null;

        public List<int> TeamIds { get; set; } = new List<int>();
    }
}
