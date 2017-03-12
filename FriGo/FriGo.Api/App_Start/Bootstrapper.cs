using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using FriGo.Api.DAL;
using FriGo.Core.Services;
using FriGo.Db.Models;
using FriGo.Interfaces.Dependencies;

namespace FriGo.Api
{
    public class Bootstrapper
    {
        private static void RegisterRequestDependencies(ContainerBuilder builder, Assembly assembly)
        {
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(IRequestDependency).IsAssignableFrom(t)).ToList();

            builder.RegisterTypes(types.ToArray()).AsImplementedInterfaces().InstancePerRequest();
        }

        private static void RegisterLifeTimeDependencies(ContainerBuilder builder, Assembly assembly)
        {
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(ILifeTimeDependency).IsAssignableFrom(t)).ToList();

            builder.RegisterTypes(types.ToArray()).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private static void RegisterSingleInstanceDependencies(ContainerBuilder builder, Assembly assembly)
        {
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(ISingleInstanceDependency).IsAssignableFrom(t)).ToList();

            builder.RegisterTypes(types.ToArray()).AsImplementedInterfaces().SingleInstance();
        }

        private static void RegisterMatchingLifeTimeDependency(ContainerBuilder builder, Assembly assembly)
        {
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(IMatchingLifeTimeDependency).IsAssignableFrom(t)).ToList();

            builder.RegisterTypes(types.ToArray()).AsImplementedInterfaces().InstancePerMatchingLifetimeScope();
        }

        private static void RegisterSelfDependency(ContainerBuilder builder, Assembly assembly)
        {
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(ISelfRequestDependency).IsAssignableFrom(t)).ToList();

            builder.RegisterTypes(types.ToArray()).AsSelf().InstancePerRequest();
        }

        public static void Run()
        {
            var otherAssemblies = new[]
            {
                Assembly.GetExecutingAssembly(),

                Assembly.GetAssembly(typeof(BaseService)),
                Assembly.GetAssembly(typeof(Entity))
            };
            
        
            var builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(otherAssemblies.First());
            builder.RegisterWebApiFilterProvider(config);

            foreach (Assembly assembly in otherAssemblies)
            {
                RegisterRequestDependencies(builder, assembly);
                RegisterLifeTimeDependencies(builder, assembly);
                RegisterSingleInstanceDependencies(builder, assembly);
                RegisterMatchingLifeTimeDependency(builder, assembly);
                RegisterSelfDependency(builder, assembly);
            }

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }        
    }
}