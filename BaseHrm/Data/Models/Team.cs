
using System.Collections.Generic;

namespace BaseHrm.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = "";

        public int? LeaderId { get; set; }
        public virtual Employee? Leader { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
    }
}
