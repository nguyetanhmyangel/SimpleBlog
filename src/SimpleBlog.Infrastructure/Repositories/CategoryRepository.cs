
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
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