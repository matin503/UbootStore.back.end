using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Online.Menu.presistance.Setting;

namespace Uboot.Store.Back.End.Application;

public class ApplicationSetup
{
    public static void AddPersistance(this IServiceCollection services)
    {
        SettingSetup.AddSettings();

        services.AddDbContext<OnlineMenuContext>(options => options.UseSqlServer(AppSettings.ConnectionString));

        services.AddScoped<OnlineMenuContext>();
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
