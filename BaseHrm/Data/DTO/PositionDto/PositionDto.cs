using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class PositionDto
    {
        public int PositionId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public int EmployeeCount { get; set; }
    }
}
