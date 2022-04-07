using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
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