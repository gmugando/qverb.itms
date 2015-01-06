using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace QverbITMS.Data.Mapping
{
     public class TaskMap : EntityTypeConfiguration<Task>
    {
         public TaskMap()
        {
            this.ToTable("Task");
            this.HasKey(i => i.Id);
        }
    }
}
