using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepositoryAsync<Category, int> _repository;

        public CategoryRepository(IRepositoryAsync<Category, int> repository)
        {
            _repository = repository;
        }
    }
}