using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface ILabelArticleRepository
    {
        IQueryable<LabelArticle> LabelArticles { get; }

        Task<List<LabelArticle>> GetListAsync();

        Task<LabelArticle> GetByIdAsync(int labelArticleId);

        Task<List<LabelArticle>> GetCachedListAsync();

        Task<LabelArticle> GetCachedByIdAsync(int labelArticleId);

        Task<int> AddAsync(LabelArticle labelArticle);

        Task UpdateAsync(LabelArticle labelArticle);

        Task DeleteAsync(LabelArticle labelArticle);
    }
}
