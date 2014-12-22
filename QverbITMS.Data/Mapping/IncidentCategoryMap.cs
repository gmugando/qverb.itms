using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Data.Mapping
{
    public class IncidentCategoryMap : EntityTypeConfiguration<IncidentCategory>
    {
        public IncidentCategoryMap()
        {
            this.ToTable("IncidentCategories");
            this.HasKey(i => i.Id);
        }
    }
}
