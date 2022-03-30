using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class AppCommandFunctionRepository : IAppCommandFunctionRepository
    {
        private readonly IRepositoryAsync<AppCommandFunction, int> _repository;

        public AppCommandFunctionRepository(IRepositoryAsync<AppCommandFunction, int> repository)
        {
            _repository = repository;
        }
    }
}