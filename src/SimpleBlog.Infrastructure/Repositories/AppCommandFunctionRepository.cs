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
    public class AppCommandFunctionRepository : IAppCommandFunctionRepository
    {
        private readonly IRepositoryAsync<AppCommandFunction> _repository;
        private readonly IDistributedCache _distributedCache;

        public AppCommandFunctionRepository(IDistributedCache distributedCache, IRepositoryAsync<AppCommandFunction> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<AppCommandFunction> AppCommandFunctions => _repository.Entities;

        public async Task DeleteAsync(AppCommandFunction appCommandFunction)
        {
            await _repository.DeleteAsync(appCommandFunction);
            await _distributedCache.RemoveAsync(AppCommandFunctionCacheKey.ListKey);
            await _distributedCache.RemoveAsync(AppCommandFunctionCacheKey.GetKey(appCommandFunction.Id));
        }

        public async Task<AppCommandFunction> GetByIdAsync(int appCommandFunctionId)
        {
            return await _repository.Entities.Where(p => p.Id == appCommandFunctionId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<AppCommandFunction> GetCachedByIdAsync(int appCommandFunctionId)
        {
            var cacheKey = AppCommandFunctionCacheKey.GetKey(appCommandFunctionId);
            var list = await _distributedCache.GetAsync<AppCommandFunction> (cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == appCommandFunctionId).FirstOrDefaultAsync() ;
                Throw.Exception.IfNull(list, "AppCommandFunction", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<AppCommandFunction>> GetCachedListAsync()
        {
            var cacheKey = AppCommandFunctionCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<AppCommandFunction>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }

        public async Task<List<AppCommandFunction>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(AppCommandFunction appCommandFunction)
        {
            await _repository.AddAsync(appCommandFunction);
            await _distributedCache.RemoveAsync(AppCommandFunctionCacheKey.ListKey);
            return appCommandFunction.Id;
        }

        public async Task UpdateAsync(AppCommandFunction appCommandFunction)
        {
            await _repository.UpdateAsync(appCommandFunction);
            await _distributedCache.RemoveAsync(AppCommandFunctionCacheKey.ListKey);
            await _distributedCache.RemoveAsync(AppCommandFunctionCacheKey.GetKey(appCommandFunction.Id));
        }
    }
}