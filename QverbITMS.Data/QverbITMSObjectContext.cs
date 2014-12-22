using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using QverbITMS.Core.Extensions;
using QverbITMS.Data.Mapping;
using QverbITMS.Data.Migrations;
using QverbITMS.Data.Setup;

namespace QverbITMS.Data
{
    /// <summary>
    /// Object context
    /// </summary>
    public class QverbITMSObjectContext : ObjectContextBase
    {

        static QverbITMSObjectContext()
        {
            var initializer = new QverbITMSDatabaseInitializer<QverbITMSObjectContext, MigrationsConfiguration>
            {
                TablesToCheck = new[] { "Incidents", "Tasks", "Projects" , "TaskCategory"}
            };

            Database.SetInitializer<QverbITMSObjectContext>(initializer);
        }

        /// <summary>
        /// For tooling support, e.g. EF Migrations
        /// </summary>
        public QverbITMSObjectContext()
            : base()
        {
        }

        public QverbITMSObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           ////dynamically load all configuration
           //var typesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
           //                       where t.Namespace.HasValue() &&
           //                             t.BaseType != null &&
           //                             t.BaseType.IsGenericType
           //                       let genericType = t.BaseType.GetGenericTypeDefinition()
           //                       where genericType == typeof(EntityTypeConfiguration<>) || genericType == typeof(ComplexTypeConfiguration<>)
           //                       select t;

           // foreach (var type in typesToRegister)
           // {
           //     dynamic configurationInstance = Activator.CreateInstance(type);
           //     modelBuilder.Configurations.Add(configurationInstance);
           // }

            ////...or do it manually below. For example,
            modelBuilder.Configurations.Add(new IncidentMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new TaskCategoryMap());
            modelBuilder.Configurations.Add(new UserProfileMap());

            // if prod use this schema
            // modelBuilder.HasDefaultSchema("wunc-za");

            base.OnModelCreating(modelBuilder);
        }

    }
}
