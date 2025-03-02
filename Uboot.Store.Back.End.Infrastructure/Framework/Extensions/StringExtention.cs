namespace Uboot.Store.Back.End.Infrastructure.Framework.Extensions;

public static class StringExtention
{
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static bool IsNullOrEmptyOrWhiteSpace(this string value)
    {
        return string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value);
    }
}
