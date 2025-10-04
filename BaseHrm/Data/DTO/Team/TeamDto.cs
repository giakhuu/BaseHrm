using BaseHrm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.DTO
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = "";
        public Employee? Leader { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<TeamMemberDto> Members { get; set; } = new();
    }

    public class TeamMemberDto
    {
        public int EmployeeId { get; set; }
        public int TeamId { get; set; }
        public string FullName { get; set; } = "";
        public bool IsLeader { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
