using Microsoft.EntityFrameworkCore;
using SimpleBlog.Application.Exceptions;
using SimpleBlog.Application.Specifications.Base;
using SimpleBlog.Domain.Contracts;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new ApiException();
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            var count = await source.CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }

        public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class, IEntity
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(query,
                    (current, include) => current.Include(include));
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));
            return secondaryResult.Where(spec.Criteria);
        }
    }
}