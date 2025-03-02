using System.Linq.Expressions;

namespace Uboot.Store.Back.End.Infrastructure.Framework.SearchExpress;

public static class Extensions
{
    public static Expression<Func<T, bool>> Combine<T>(this List<FilterCriterion<T>> filters)
    {
        return ExpressionBuilder.CombineFilters<T>(filters);
    }

    public static IQueryable<T> OrderFilters<T>(this ICollection<FilterCriterion<T>> filters, IQueryable<T> query)
    {
        return ExpressionBuilder.OrderFilters(query, filters);
    }
    public static IQueryable<T> OrderFilters<T>(this IQueryable<T> query, ICollection<FilterCriterion<T>> filters)
    {
        return ExpressionBuilder.OrderFilters(query, filters);
    }
}
