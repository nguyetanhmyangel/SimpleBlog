//using Application.Exceptions;
//using Infrastructure.Share.Wrapper;
//using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Application.Extensions
{
    public static class QueryableExtensions
    {
        //public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        //{
        //    if (source == null) throw new ApiException();
        //    pageNumber = pageNumber == 0 ? 1 : pageNumber;
        //    pageSize = pageSize == 0 ? 10 : pageSize;
        //    var count = await source.CountAsync();
        //    pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        //    var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        //    return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        //}
    }
}