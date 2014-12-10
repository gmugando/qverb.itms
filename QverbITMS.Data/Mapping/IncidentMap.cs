using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Data.Mapping
{
    public class IncidentMap : EntityTypeConfiguration<Incident>
    {
        public IncidentMap()
        {
            this.ToTable("Incidents");
            this.HasKey(i => i.Id);
        }
    }
}
