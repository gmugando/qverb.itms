using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Data.Mapping
{
    public class TaskCategoryMap : EntityTypeConfiguration<TaskCategory>
    {
        public TaskCategoryMap()
        {
            this.ToTable("TaskCategory");
            this.HasKey(i => i.Id);
        }
    }
}
