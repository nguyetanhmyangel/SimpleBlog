using System.Linq.Expressions;
using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Application.Interfaces
{
    public interface IRepositoryAsync<T, K> where T : class, IEntity<K>
    {
        IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindById(K id, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<List<T>> FindAllAsync();

        Task<List<T>> FindPagedAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task Remove(K id);

        void RemoveMultiple(List<T> entities);
    }
}
