using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class UpdatePositionDto : CreatePositionDto
    {
        public int PositionId { get; set; }
    }
}
