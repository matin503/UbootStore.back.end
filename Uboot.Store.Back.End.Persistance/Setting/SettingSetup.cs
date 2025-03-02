using Uboot.Store.Back.End.Infrastructure.Framework.Commons;

namespace Uboot.Store.Back.End.Persistance.Setting;

internal static class SettingSetup
{
    public static void AddSettings()
    {
        AppSettings.ConnectionString = SettingCommon.GetSetting<string>("ConnectionStrings");
    }
}
