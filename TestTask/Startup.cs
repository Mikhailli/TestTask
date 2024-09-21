﻿#nullable enable
using API.Settings;
using Autofac;
using Data.Implementations;
using Infrastructure.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace API;

public class Startup
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public IConfiguration Configuration { get; }

    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        _hostingEnvironment = env;
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AppSettings>(Configuration);
        services.AddDbContext<PharmacyDbContext>();
        services.AddHttpContextAccessor();

        services.AddControllers();
    }

    public void ConfigureContainer(HostBuilderContext hostBuilderContext, ContainerBuilder builder)
    {
        builder.RegisterModule(new RepositoriesModule());
        builder.RegisterModule(new ServicesModule());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}
