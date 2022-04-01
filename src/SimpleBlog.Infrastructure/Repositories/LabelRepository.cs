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
    public class LabelRepository : ILabelRepository
    {
        private readonly IRepositoryAsync<Label> _repository;
        private readonly IDistributedCache _distributedCache;

        public LabelRepository(IDistributedCache distributedCache, IRepositoryAsync<Label> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Label> Labels => _repository.Entities;

        public async Task DeleteAsync(Label label)
        {
            await _repository.DeleteAsync(label);
            await _distributedCache.RemoveAsync(LabelCacheKey.ListKey);
            await _distributedCache.RemoveAsync(LabelCacheKey.GetKey(label.Id));
        }

        public async Task<Label> GetByIdAsync(int labelId)
        {
            return await _repository.Entities.Where(p => p.Id == labelId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Label> GetCachedByIdAsync(int labelId)
        {
            var cacheKey = LabelCacheKey.GetKey(labelId);
            var list = await _distributedCache.GetAsync<Label>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == labelId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "Label", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<Label>> GetCachedListAsync()
        {
            var cacheKey = LabelCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<Label>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }


        public async Task<List<Label>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(Label label)
        {
            await _repository.AddAsync(label);
            await _distributedCache.RemoveAsync(LabelCacheKey.ListKey);
            return label.Id;
        }

        public async Task UpdateAsync(Label label)
        {
            await _repository.UpdateAsync(label);
            await _distributedCache.RemoveAsync(LabelCacheKey.ListKey);
            await _distributedCache.RemoveAsync(LabelCacheKey.GetKey(label.Id));
        }
    }
}