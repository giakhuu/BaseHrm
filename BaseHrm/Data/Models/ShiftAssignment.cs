using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace BaseHrm.Data.Models
{
    public class ShiftAssignment
    {
        public int ShiftAssignmentId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int ShiftId { get; set; }
        public Shift Shift { get; set; } = null!;

        public DateTime Date { get; set; }

        public int? ApprovedByAccountId { get; set; }
        public Account? ApprovedByAccount { get; set; }
    }
}

