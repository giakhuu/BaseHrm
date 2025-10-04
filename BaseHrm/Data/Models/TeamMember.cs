using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Models
{
    public class TeamMember
    {
        public int TeamId { get; set; }
        public Team? Team { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public bool IsLeader { get; set; } = false;

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}