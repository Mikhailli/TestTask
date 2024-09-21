#nullable enable
using Autofac;
using Data.Services.Implementations;
using Module = Autofac.Module;

namespace Infrastructure.Modules;

public class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var servicesAssembly = typeof(MedicineService).Assembly;

        builder.RegisterAssemblyTypes(servicesAssembly)
            .Where(type => type.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
