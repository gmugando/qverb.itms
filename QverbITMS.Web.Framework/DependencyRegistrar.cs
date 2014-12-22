using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QverbITMS.Core.Infrastructure.DependencyManagement;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Builder;
using Autofac.Core;
using QverbITMS.Core;
using QverbITMS.Data;
using QverbITMS.Core.Data;
using QverbITMS.Services;
using QverbITMS.Services.Interfaces;

namespace QverbITMS.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            // modules
            builder.RegisterModule(new DbModule());

            // work context
            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();

            //services
            builder.RegisterType<IncidentService>().As<IIncidentService>().InstancePerLifetimeScope();
            builder.RegisterType<IncidentCategoryService>().As<IIncidentCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return -100; }
        }
    }

    #region Modules

    public class DbModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new EfDataProviderFactory(x.Resolve<DataSettings>())).As<DataProviderFactory>().InstancePerDependency();

            builder.Register(x => x.Resolve<DataProviderFactory>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            builder.Register<IDbContext>(c => new QverbITMSObjectContext(DataSettings.Current.DataConnectionString))
                    .PropertiesAutowired(PropertyWiringOptions.None)
                    .InstancePerHttpRequest();

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }

    #endregion
}
