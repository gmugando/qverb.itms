using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QverbITMS.Core.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
