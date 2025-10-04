using System;
using System.Collections.Generic;

namespace BaseHrm.Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";

        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal MaxHoursPerDay { get; set; } = 8.00m;
        public decimal MaxHoursPerMonth { get; set; } = 160.00m;

        public virtual ICollection<TeamMember> TeamMemberships { get; set; } = new List<TeamMember>();
        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
        public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();

        public virtual Account? Account { get; set; }

        public int? PositionId { get; set; }
        public Position? Position { get; set; }

    }
}
