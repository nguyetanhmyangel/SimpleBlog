using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class AppPermissionRepository : IAppPermissionRepository
    {
        private readonly IRepositoryAsync<AppPermission, int> _repository;

        public AppPermissionRepository(IRepositoryAsync<AppPermission, int> repository)
        {
            _repository = repository;
        }
    }
}