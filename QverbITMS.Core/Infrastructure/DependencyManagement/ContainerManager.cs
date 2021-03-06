﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;

namespace QverbITMS.Core.Infrastructure.DependencyManagement
{
    public class ContainerManager
    {
        private readonly IContainer _container;

        public ContainerManager(IContainer container)
        {
            _container = container;
        }

        public IContainer Container
        {
            get { return _container; }
        }

        public T Resolve<T>(string key = "", ILifetimeScope scope = null) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                return (scope ?? Scope()).Resolve<T>();
            }
            return (scope ?? Scope()).ResolveKeyed<T>(key);
        }

        public T ResolveNamed<T>(string name, ILifetimeScope scope = null) where T : class
        {
            return (scope ?? Scope()).ResolveNamed<T>(name);
        }

        public object Resolve(Type type, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).Resolve(type);
        }

        public object ResolveNamed(string name, Type type, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).ResolveNamed(name, type);
        }

        public T[] ResolveAll<T>(string key = "", ILifetimeScope scope = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                return (scope ?? Scope()).Resolve<IEnumerable<T>>().ToArray();
            }
            return (scope ?? Scope()).ResolveKeyed<IEnumerable<T>>(key).ToArray();
        }

        public T ResolveUnregistered<T>(ILifetimeScope scope = null) where T : class
        {
            return ResolveUnregistered(typeof(T), scope) as T;
        }

        public object ResolveUnregistered(Type type, ILifetimeScope scope = null)
        {
            var constructors = type.GetConstructors();
            foreach (var constructor in constructors)
            {
                try
                {
                    var parameters = constructor.GetParameters();
                    var parameterInstances = new List<object>();
                    foreach (var parameter in parameters)
                    {
                        var service = Resolve(parameter.ParameterType, scope);
                        if (service == null)
                            throw new QverbITMSException("Unkown dependency");
                        parameterInstances.Add(service);
                    }
                    return Activator.CreateInstance(type, parameterInstances.ToArray());
                }
                catch (QverbITMSException)
                {

                }
            }
            throw new QverbITMSException("No contructor was found that had all the dependencies satisfied.");
        }

        public bool TryResolve(Type serviceType, ILifetimeScope scope, out object instance)
        {
            return (scope ?? Scope()).TryResolve(serviceType, out instance);
        }

        public bool TryResolve<T>(ILifetimeScope scope, out T instance)
        {
            return (scope ?? Scope()).TryResolve<T>(out instance);
        }

        public bool IsRegistered(Type serviceType, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).IsRegistered(serviceType);
        }

        public object ResolveOptional(Type serviceType, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).ResolveOptional(serviceType);
        }

        public T InjectProperties<T>(T instance, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).InjectProperties(instance);
        }

        public T InjectUnsetProperties<T>(T instance, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).InjectUnsetProperties(instance);
        }

        public ILifetimeScope Scope()
        {
            ILifetimeScope scope = null;
            try
            {
                scope = AutofacDependencyResolver.Current.RequestLifetimeScope;
            }
            catch { }

            if (scope == null)
            {
                // really hackisch. But strange things are going on ?? :-)
                scope = _container.BeginLifetimeScope("AutofacWebRequest");
            }

            return scope ?? _container;
        }

    }

    public static class ContainerManagerExtensions
    {
        //public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithStaticCache<TLimit, TReflectionActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration) where TReflectionActivatorData : ReflectionActivatorData
        //{
        //    return registration.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<ICacheManager>("static"));
        //}

        //public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithAspNetCache<TLimit, TReflectionActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration) where TReflectionActivatorData : ReflectionActivatorData
        //{
        //    return registration.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<ICacheManager>("aspnet"));
        //}

        //public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithNullCache<TLimit, TReflectionActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration) where TReflectionActivatorData : ReflectionActivatorData
        //{
        //    return registration.WithParameter(Autofac.Core.ResolvedParameter.ForNamed<ICacheManager>("null"));
        //}

    }
}
