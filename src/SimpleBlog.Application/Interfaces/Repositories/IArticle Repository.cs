using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IArticleRepository
    {
        IQueryable<Article> Articles { get; }

        Task<List<Article>> GetListAsync();

        Task<Article> GetByIdAsync(int articleId);

        Task<List<Article>> GetCachedListAsync();

        Task<Article> GetCachedByIdAsync(int articleId);

        Task<int> AddAsync(Article article);

        Task UpdateAsync(Article article);

        Task DeleteAsync(Article article);
    }
}
