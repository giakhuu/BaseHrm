using System.Collections.Generic;
using BaseHrm.Data.DTO;

namespace BaseHrm.Data.Service
{
    public class ShiftBackupDto
    {
        public List<ShiftDto> Shifts { get; set; } = new();
        public List<ShiftAssignmentDto> ShiftAssignments { get; set; } = new();
    }
}
