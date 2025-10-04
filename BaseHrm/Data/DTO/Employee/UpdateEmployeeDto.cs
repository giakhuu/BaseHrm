using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class UpdateEmployeeDto : CreateEmployeeDto
    {
        public int EmployeeId { get; set; }
    }
}
