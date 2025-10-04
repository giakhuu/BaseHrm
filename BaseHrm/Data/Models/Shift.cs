using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace BaseHrm.Data.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public string Name { get; set; } = ""; 

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public decimal ExpectedHours { get; set; }

        public int ShiftTypeId { get; set; }
        public ShiftType? ShiftType { get; set; }

    }
}
