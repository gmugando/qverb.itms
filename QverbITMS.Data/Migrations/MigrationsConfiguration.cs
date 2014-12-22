using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Data.Migrations
{
    public sealed class MigrationsConfiguration : DbMigrationsConfiguration<QverbITMSObjectContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            //ContextKey = "QverbITMS.Core";
        }

        protected override void Seed(QverbITMSObjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Incidents.AddOrUpdate(
            //  p => p.FullName,
            //  new Incident { Name = "Andrew Peters" },
            //  new Incident { Name = "Brice Lambson" },
            //  new Incident { Name = "Rowan Miller" }
            //);
            
        }
    }
}
