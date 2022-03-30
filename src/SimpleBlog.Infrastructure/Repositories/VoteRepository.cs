using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly IRepositoryAsync<Vote, int> _repository;

        public VoteRepository(IRepositoryAsync<Vote, int> repository)
        {
            _repository = repository;
        }
    }
}