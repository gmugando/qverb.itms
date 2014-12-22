using Autofac;
using Autofac.Integration.Mvc;
using QverbITMS.Core.Infrastructure;
using QverbITMS.Core.Infrastructure.DependencyManagement;
using QverbITMS.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QverbITMS.Core
{
    public class QverbITMSEngine : IEngine
    {
        private ContainerManager _containerManager;

        public void Initialize()
        {
            RegisterDependencies();
        }

        public T Resolve<T>(string name = null) where T : class
        {
            if (name.HasValue())
            {
                return ContainerManager.ResolveNamed<T>(name);
            }
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type, string name = null)
        {
            if (name.HasValue())
            {
                return ContainerManager.ResolveNamed(name, type);
            }
            return ContainerManager.Resolve(type);
        }

        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }

        #region Utilities

        protected virtual void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            // core dependencies
            builder = new ContainerBuilder();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.RegisterType<WebAppTypeFinder>().As<ITypeFinder>().SingleInstance();
            builder.Update(container);

            // register dependencies provided by other assemblies
            var typeFinder = container.Resolve<ITypeFinder>();
            builder = new ContainerBuilder();
            var registrarTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var registrarInstances = new List<IDependencyRegistrar>();
            foreach (var type in registrarTypes)
            {
                registrarInstances.Add((IDependencyRegistrar)Activator.CreateInstance(type));
            }
            // sort
            registrarInstances = registrarInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var registrar in registrarInstances)
            {
                registrar.Register(builder, typeFinder, true); //TODO : use a variable to check if module shld be registered
            }
            builder.Update(container);

            // AutofacDependencyResolver
            var scopeProvider = new AutofacLifetimeScopeProvider(container);
            var dependencyResolver = new AutofacDependencyResolver(container, scopeProvider);
            DependencyResolver.SetResolver(dependencyResolver);

            _containerManager = new ContainerManager(container);
        }

        #endregion

        #region Properties

        public IContainer Container
        {
            get { return _containerManager.Container; }
        }

        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        #endregion
    }
}
