﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHrm.Data.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
