using System.Linq.Expressions;

namespace Uboot.Store.Back.End.Infrastructure.Framework.SearchExpress;

public static class ExpressionBuilder
{
    public static Expression<Func<T, bool>> CombineFilters<T>(List<FilterCriterion<T>> filters)
    {
        if (filters is null || filters.Count == 0)
            throw new ArgumentException("At least one filter must be provided.");

        var predicate = PredicateBuilder.True<T>();

        foreach (var filter in filters.Where(x => x.Value != null))
        {
            var filterExpression = BuildFilterExpression(filter);

            predicate = filter.LogicalOperation == LogicalOperation.And ? predicate.And(filterExpression) : predicate.Or(filterExpression);
        }

        return predicate;
    }

    public static Expression<Func<T, bool>> CombineFilterExpressions<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2, LogicalOperation logicalOperation)
    {
        var parameter = Expression.Parameter(typeof(T), "x");

        Expression combinedExpression = logicalOperation switch
        {
            LogicalOperation.And => Expression.AndAlso(Expression.Invoke(expr1, parameter), Expression.Invoke(expr2, parameter)),
            LogicalOperation.Or => Expression.OrElse(Expression.Invoke(expr1, parameter), Expression.Invoke(expr2, parameter)),
            _ => throw new InvalidOperationException("Unsupported logical operation")
        };

        return Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
    }

    public static IQueryable<T> OrderFilters<T>(IQueryable<T> query, ICollection<FilterCriterion<T>> filters)
    {
        if (!filters.Any(f => f.OrderDirection.HasValue))
            return query;

        IOrderedQueryable<T> orderedQuery = null;

        foreach (var filter in filters.Where(f => f.OrderDirection.HasValue))
        {
            var propertyName = ((MemberExpression)(filter.PropertyExpression.Body is UnaryExpression unary
                ? unary.Operand
                : filter.PropertyExpression.Body)).Member.Name;

            if (orderedQuery == null)
            {
                orderedQuery = query.OrderByDynamic(propertyName, filter.OrderDirection.Value);
            }
            else
            {
                orderedQuery = orderedQuery.ThenByDynamic(propertyName, filter.OrderDirection.Value);
            }
        }

        return orderedQuery;
    }

    private static Expression<Func<T, bool>> BuildFilterExpression<T>(FilterCriterion<T> criterion)
    {
        var parameter = Expression.Parameter(typeof(T), "x");

        // Get the property specified in PropertyExpression
        var propertyExpression = (MemberExpression)(criterion.PropertyExpression.Body is UnaryExpression unary
            ? unary.Operand
            : criterion.PropertyExpression.Body);

        var property = Expression.Property(parameter, propertyExpression.Member.Name);

        // Create the comparison expression based on the filter operation
        Expression condition = criterion.Operation switch
        {
            FilterOperation.Equal => Expression.Equal(property, Expression.Constant(criterion.Value)),
            FilterOperation.NotEqual => Expression.NotEqual(property, Expression.Constant(criterion.Value)),
            FilterOperation.Contains => Expression.Call(property, typeof(string).GetMethod("Contains", [typeof(string)])!, Expression.Constant(criterion.Value)),
            FilterOperation.StartsWith => Expression.Call(property, typeof(string).GetMethod("StartsWith", [typeof(string)])!, Expression.Constant(criterion.Value)),
            FilterOperation.EndsWith => Expression.Call(property, typeof(string).GetMethod("EndsWith", [typeof(string)])!, Expression.Constant(criterion.Value)),
            FilterOperation.GreaterThan => Expression.GreaterThan(property, Expression.Constant(criterion.Value)),
            FilterOperation.LessThan => Expression.LessThan(property, Expression.Constant(criterion.Value)),
            _ => throw new NotSupportedException($"Operation '{criterion.Operation}' is not supported.")
        };

        return Expression.Lambda<Func<T, bool>>(condition, parameter);
    }
}
