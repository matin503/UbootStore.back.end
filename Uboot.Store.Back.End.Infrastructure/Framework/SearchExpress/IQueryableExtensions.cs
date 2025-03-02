using System.Linq.Expressions;

namespace Uboot.Store.Back.End.Infrastructure.Framework.SearchExpress;

public static class IQueryableExtensions
{
    public static IOrderedQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string propertyName, OrderDirection direction)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(param, propertyName);
        var lambda = Expression.Lambda(property, param);

        var methodName = direction == OrderDirection.Asc ? "OrderBy" : "OrderByDescending";
        var methodCallExpression = Expression.Call(typeof(Queryable), methodName, [typeof(T), property.Type], source.Expression, lambda);

        return (IOrderedQueryable<T>)source.Provider.CreateQuery(methodCallExpression);
    }

    public static IOrderedQueryable<T> ThenByDynamic<T>(this IOrderedQueryable<T> source, string propertyName, OrderDirection direction)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(param, propertyName);
        var lambda = Expression.Lambda(property, param);

        var methodName = direction == OrderDirection.Asc ? "ThenBy" : "ThenByDescending";
        var methodCallExpression = Expression.Call(typeof(Queryable), methodName, [typeof(T), property.Type], source.Expression, lambda);

        return (IOrderedQueryable<T>)source.Provider.CreateQuery(methodCallExpression);
    }
}
