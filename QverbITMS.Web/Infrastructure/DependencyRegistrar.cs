using Autofac;
using Autofac.Integration.Mvc;
using QverbITMS.Core;
using QverbITMS.Core.Infrastructure.DependencyManagement;
using QverbITMS.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QverbITMS.Web.Infrastructure
{
 /// <summary>
 /// Register 
 /// </summary>
    public class DependencyRegistrar: IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            //we cache presentation models between requests
            //builder.RegisterType<HomeController>();
            //builder.RegisterType<HomeController>().WithStaticCache(); //TODO : add caching

            //alternatively register all controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
        }


        public int Order
        {
            get { return 2; }
        }
    }
}