using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Uboot.Store.Back.End.Domain;
using Uboot.Store.Back.End.Infrastructure.Framework.Mediators;

namespace Uboot.Store.Back.End.Application;

public static class ApplicationSetup
{
    public static void AddApplicationServices(this IServiceCollection services, Assembly assembly)
    {
        var applicationAssembly = AppDomain.CurrentDomain.Load("Uboot.Store.Back.End.Application");
        services.AddMediatorServices(applicationAssembly);

        services.AddAutoMapper(assembly, applicationAssembly);

        services.AddDomainServices();
    }
}

