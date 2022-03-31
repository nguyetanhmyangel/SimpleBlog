using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }

        Task<List<Category>> GetListAsync();

        Task<Category> GetByIdAsync(int categoryId);

        Task<List<Category>> GetCachedListAsync();

        Task<Category> GetCachedByIdAsync(int categoryId);

        Task<int> AddAsync(Category category);

        Task UpdateAsync(Category category);

        Task DeleteAsync(Category category);
    }
}
