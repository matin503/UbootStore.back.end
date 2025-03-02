namespace Uboot.Store.Back.End.Infrastructure.Framework.Extensions;

public static class CollectionExtension
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
    {
        return value == null || !value.Any();
    }

}
