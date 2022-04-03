using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Infrastructure.CacheKeys;
using SimpleBlog.Infrastructure.Share.Caching;
using SimpleBlog.Infrastructure.Share.ThrowR;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly IRepositoryAsync<Vote> _repository;
        private readonly IDistributedCache _distributedCache;

        public VoteRepository(IDistributedCache distributedCache, IRepositoryAsync<Vote> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Vote> Votes => _repository.Entities;

        public async Task DeleteAsync(Vote vote)
        {
            await _repository.DeleteAsync(vote);
            await _distributedCache.RemoveAsync(VoteCacheKey.ListKey);
            await _distributedCache.RemoveAsync(VoteCacheKey.GetKey(vote.Id));
        }

        public async Task<Vote> GetByIdAsync(int VoteId)
        {
            return await _repository.Entities.Where(p => p.Id == VoteId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Vote?> GetCachedByIdAsync(int voteId)
        {
            var cacheKey = VoteCacheKey.GetKey(voteId);
            var list = await _distributedCache.GetAsync<Vote>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == voteId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "Vote", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<Vote>> GetCachedListAsync()
        {
            var cacheKey = VoteCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<Vote>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }


        public async Task<List<Vote>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(Vote vote)
        {
            await _repository.AddAsync(vote);
            await _distributedCache.RemoveAsync(VoteCacheKey.ListKey);
            return vote.Id;
        }

        public async Task UpdateAsync(Vote vote)
        {
            await _repository.UpdateAsync(vote);
            await _distributedCache.RemoveAsync(VoteCacheKey.ListKey);
            await _distributedCache.RemoveAsync(VoteCacheKey.GetKey(vote.Id));
        }
    }
}