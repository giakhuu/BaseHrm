using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class CreatePositionDto
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
    }
}
