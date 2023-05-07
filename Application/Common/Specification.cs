using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Common;

public interface ISpecification<T>
{
    public Expression<Func<T,bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; }
    public List<string> IncludeStrings { get; }
}

public abstract class BaseSpecification<T>: ISpecification<T>
{
    public Expression<Func<T,bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();
    public List<string> IncludeStrings { get; } = new();
    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }
}

public static class SpecificationExtensions
{
    public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> query, ISpecification<TSource> spec)
        where TSource : class
    {
        var queryableResultWithIncludes = spec.Includes
            .Aggregate(query,
                (current, include) => current.Include(include));

        var secondaryResult = spec.IncludeStrings
            .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));

        return secondaryResult
            .Where(spec.Criteria);
    }
}