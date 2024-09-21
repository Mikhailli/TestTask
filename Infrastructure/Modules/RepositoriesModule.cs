﻿#nullable enable
using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace Infrastructure.Modules;

public class RepositoriesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EFGenericRepsitory<>))
            .As(typeof(IGenericRepository<>))
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        var repositoryAssembly = typeof(EFGenericRepsitory<>).GetTypeInfo().Assembly;

        builder.RegisterAssemblyTypes(repositoryAssembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
