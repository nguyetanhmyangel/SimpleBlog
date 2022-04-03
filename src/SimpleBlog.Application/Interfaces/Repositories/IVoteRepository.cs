using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IVoteRepository
    {
        IQueryable<Vote> Votes { get; }

        Task<List<Vote>> GetListAsync();

        Task<Vote> GetByIdAsync(int voteId);

        Task<List<Vote>> GetCachedListAsync();

        Task<Vote?> GetCachedByIdAsync(int voteId);

        Task<int> AddAsync(Vote vote);

        Task UpdateAsync(Vote vote);

        Task DeleteAsync(Vote vote);
    }
}
