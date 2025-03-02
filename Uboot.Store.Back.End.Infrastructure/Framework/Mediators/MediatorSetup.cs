using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Uboot.Store.Back.End.Infrastructure.Framework.Mediators;

public static class MediatorSetup
{
    public static void AddMediatorServices(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IMediatorFacade, MediatorFacade>();
        services.AddTransient<IMediatorService, MediatorService>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

    }
}
