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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepositoryAsync<Category> _repository;
        private readonly IDistributedCache _distributedCache;

        public CategoryRepository(IDistributedCache distributedCache, IRepositoryAsync<Category> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Category> Categories => _repository.Entities;

        public async Task DeleteAsync(Category category)
        {
            await _repository.DeleteAsync(category);
            await _distributedCache.RemoveAsync(CategoryCacheKey.ListKey);
            await _distributedCache.RemoveAsync(CategoryCacheKey.GetKey(category.Id));
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await _repository.Entities.Where(p => p.Id == categoryId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Category> GetCachedByIdAsync(int categoryId)
        {
            var cacheKey = CategoryCacheKey.GetKey(categoryId);
            var list = await _distributedCache.GetAsync<Category>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == categoryId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "Category", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<Category>> GetCachedListAsync()
        {
            var cacheKey = CategoryCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<Category>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }

        public async Task<List<Category>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(Category category)
        {
            await _repository.AddAsync(category);
            await _distributedCache.RemoveAsync(CategoryCacheKey.ListKey);
            return category.Id;
        }

        public async Task UpdateAsync(Category category)
        {
            await _repository.UpdateAsync(category);
            await _distributedCache.RemoveAsync(CategoryCacheKey.ListKey);
            await _distributedCache.RemoveAsync(CategoryCacheKey.GetKey(category.Id));
        }
    }
}