using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class AppCommandRepository : IAppCommandFunctionRepository
    {
        private readonly IRepositoryAsync<AppCommand, int> _repository;

        public AppCommandRepository(IRepositoryAsync<AppCommand, int> repository)
        {
            _repository = repository;
        }
    }
}