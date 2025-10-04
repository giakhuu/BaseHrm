using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime HireDate { get; set; } = DateTime.UtcNow;
        public decimal MaxHoursPerDay { get; set; } = 8;
        public decimal MaxHoursPerMonth { get; set; } = 160;
        public int? PositionId { get; set; } = null;
    }
}
