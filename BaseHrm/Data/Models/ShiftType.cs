using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace BaseHrm.Data.Models
{
    public class ShiftType
    {
        public int ShiftTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal PayMultiplier { get; set; }
        public List<Shift>? Shifts { get; set; }
    }
}
