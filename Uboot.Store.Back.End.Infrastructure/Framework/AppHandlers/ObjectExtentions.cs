namespace Uboot.Store.Back.End.Infrastructure.Framework.AppHandlers;

public static class ObjectExtentions
{
    public static IEnumerable<T> ToEnumerable<T>(this T value)
    {
        yield return value;
    }
}
