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
    public class LabelArticleRepository : ILabelArticleRepository
    {
        private readonly IRepositoryAsync<LabelArticle> _repository;
        private readonly IDistributedCache _distributedCache;

        public LabelArticleRepository(IDistributedCache distributedCache, IRepositoryAsync<LabelArticle> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<LabelArticle> LabelArticles => _repository.Entities;

        public async Task DeleteAsync(LabelArticle labelArticle)
        {
            await _repository.DeleteAsync(labelArticle);
            await _distributedCache.RemoveAsync(LabelArticleCacheKey.ListKey);
            await _distributedCache.RemoveAsync(LabelArticleCacheKey.GetKey(labelArticle.Id));
        }

        public async Task<LabelArticle> GetByIdAsync(int labelArticleId)
        {
            return await _repository.Entities.Where(p => p.Id == labelArticleId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<LabelArticle> GetCachedByIdAsync(int labelArticleId)
        {
            var cacheKey = LabelArticleCacheKey.GetKey(labelArticleId);
            var list = await _distributedCache.GetAsync<LabelArticle>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == labelArticleId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "LabelArticle", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }

        public async Task<List<LabelArticle>> GetCachedListAsync()
        {
            var cacheKey = LabelArticleCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<LabelArticle>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }

        public async Task<List<LabelArticle>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(LabelArticle labelArticle)
        {
            await _repository.AddAsync(labelArticle);
            await _distributedCache.RemoveAsync(LabelArticleCacheKey.ListKey);
            return labelArticle.Id;
        }

        public async Task UpdateAsync(LabelArticle labelArticle)
        {
            await _repository.UpdateAsync(labelArticle);
            await _distributedCache.RemoveAsync(LabelArticleCacheKey.ListKey);
            await _distributedCache.RemoveAsync(LabelArticleCacheKey.GetKey(labelArticle.Id));
        }
    }
}