using Microsoft.Extensions.DependencyInjection;
using Uboot.Store.Back.End.Persistance.Setting;

namespace Uboot.Store.Back.End.Persistance;

public static class PersistanceSetup
{
    public static void AddPersistance(this IServiceCollection services)
    {
        SettingSetup.AddSettings();

        services.AddDbContext<UbootStoreContext>(options => options.UseSqlServer(AppSettings.ConnectionString));

        services.AddScoped<UbootStoreContext>();
        services.AddScoped((s) => new SqlConnection(AppSettings.ConnectionString));

        typeof(ABaseRepository)
            .Assembly
            .DefinedTypes
            .Where(repo => !repo.IsAbstract && repo.IsSubclassOf(typeof(ABaseRepository)))
            .ToList()
            .ForEach(repo =>
            {
                var irepo = repo.GetInterface($"I{repo.Name}");
                services.AddScoped(irepo, repo);
            });
    }
}
