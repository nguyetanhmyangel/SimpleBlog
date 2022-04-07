using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IRepositoryAsync<Menu, int> _repository;

        public MenuRepository(IRepositoryAsync<Menu, int> repository)
        {
            _repository = repository;
        }
    }
}