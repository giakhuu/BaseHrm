using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace BaseHrm.Data.Models
{
    public class AttendanceRecord
    {
        public int AttendanceRecordId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public decimal? DurationHours { get; set; }

        public bool IsOvertime { get; set; } = false;

        public int? ShiftAssignmentId { get; set; }
        public ShiftAssignment? ShiftAssignment { get; set; }
    }
}

