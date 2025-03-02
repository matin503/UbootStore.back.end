using System.Linq.Expressions;

namespace Uboot.Store.Back.End.Infrastructure.Framework.SearchExpress;


//public class OrderCriterion<T>
//{
//    public Expression<Func<T, object>> PropertyExpression { get; set; } // The property to order by
//    public OrderDirection Direction { get; set; } // Ascending or Descending
//}

public static class PredicateBuilder
{
    // Returns a predicate that always evaluates to true
    public static Expression<Func<T, bool>> True<T>() { return x => true; }

    // Returns a predicate that always evaluates to false
    public static Expression<Func<T, bool>> False<T>() { return x => false; }

    // Combines two expressions with an OR condition
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        // Combine the body of both expressions
        var combined = Expression.OrElse(
            new ReplaceParameterVisitor(expr1.Parameters[0], parameter).Visit(expr1.Body),
            new ReplaceParameterVisitor(expr2.Parameters[0], parameter).Visit(expr2.Body));

        return Expression.Lambda<Func<T, bool>>(combined, parameter);
    }

    // Combines two expressions with an AND condition
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        // Combine the body of both expressions
        var combined = Expression.AndAlso(
            new ReplaceParameterVisitor(expr1.Parameters[0], parameter).Visit(expr1.Body),
            new ReplaceParameterVisitor(expr2.Parameters[0], parameter).Visit(expr2.Body));

        return Expression.Lambda<Func<T, bool>>(combined, parameter);
    }

    // Internal class to handle replacing parameters in an expression tree
    private class ReplaceParameterVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _oldParam;
        private readonly ParameterExpression _newParam;

        public ReplaceParameterVisitor(ParameterExpression oldParam, ParameterExpression newParam)
        {
            _oldParam = oldParam;
            _newParam = newParam;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _oldParam ? _newParam : base.VisitParameter(node);
        }
    }
}
