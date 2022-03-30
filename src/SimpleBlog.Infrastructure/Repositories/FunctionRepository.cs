using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class FunctionRepository : IFunctionRepository
    {
        private readonly IRepositoryAsync<Function, int> _repository;

        public FunctionRepository(IRepositoryAsync<Function, int> repository)
        {
            _repository = repository;
        }
    }
}