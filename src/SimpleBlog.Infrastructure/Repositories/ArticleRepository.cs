using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IRepositoryAsync<Article, int> _repository;

        public ArticleRepository(IRepositoryAsync<Article, int> repository)
        {
            _repository = repository;
        }
    }
}