using Microsoft.Extensions.Configuration;

namespace Uboot.Store.Back.End.Infrastructure.Framework.Commons;

public class SettingCommon
{
    public static IConfigurationRoot Configuration { get; private set; }

    public static void AddJsonSettingFilesConfiguration()
    {
        var executeDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        var settingDirectoryPath = Path.Combine(executeDirectoryPath, "Settings");

        var builder = new ConfigurationBuilder().SetBasePath(settingDirectoryPath);

        var filesFullPath = Directory.GetFiles(settingDirectoryPath, $"*.json")
                                     .Where(x => !x.ToLower().EndsWith("mock.json"));

        foreach (var fileFullPath in filesFullPath)
            builder.AddJsonFile(fileFullPath, optional: true, reloadOnChange: true);

        Configuration = builder.Build();
    }

    public static T GetSetting<T>(string key)
    {
        return Configuration.GetSection(key).Get<T>();
    }
}
