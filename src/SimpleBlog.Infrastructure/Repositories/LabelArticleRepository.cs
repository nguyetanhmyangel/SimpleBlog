using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class LabelArticleRepository : ILabelArticleRepository
    {
        private readonly IRepositoryAsync<LabelArticle, int> _repository;

        public LabelArticleRepository(IRepositoryAsync<LabelArticle, int> repository)
        {
            _repository = repository;
        }
    }
}