using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Data.Setup
{
    public class QverbITMSDatabaseInitializer<TContext, TConfig> : IDatabaseInitializer<TContext>
        where TContext : DbContext, new()
        where TConfig : DbMigrationsConfiguration<TContext>, new()
    {
        public QverbITMSDatabaseInitializer()
        {

        }

        public QverbITMSDatabaseInitializer(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        #region Properties

        public IEnumerable<string> TablesToCheck
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            private set;
        }

        #endregion

        public void InitializeDatabase(TContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
