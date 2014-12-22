using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QverbITMS.Core.Enums;

namespace QverbITMS.Core.Domain
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Descr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskCategory Category { get; set; }
        public int ProjectId { get; set; }
        public int AssignedTo { get; set; } // user
        public bool Status { get; set; } // open or closed
        public PriorityEnum Priority { get; set; }


    }
}
