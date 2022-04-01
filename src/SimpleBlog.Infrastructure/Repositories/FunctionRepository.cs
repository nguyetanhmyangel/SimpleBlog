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
    public class FunctionRepository : IFunctionRepository
    {
        private readonly IRepositoryAsync<Function> _repository;
        private readonly IDistributedCache _distributedCache;

        public FunctionRepository(IDistributedCache distributedCache, IRepositoryAsync<Function> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Function> Functions => _repository.Entities;

        public async Task DeleteAsync(Function function)
        {
            await _repository.DeleteAsync(function);
            await _distributedCache.RemoveAsync(FunctionCacheKey.ListKey);
            await _distributedCache.RemoveAsync(FunctionCacheKey.GetKey(function.Id));
        }

        public async Task<Function> GetByIdAsync(int functionId)
        {
            return await _repository.Entities.Where(p => p.Id == functionId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Function> GetCachedByIdAsync(int functionId)
        {
            var cacheKey = FunctionCacheKey.GetKey(functionId);
            var list = await _distributedCache.GetAsync<Function>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == functionId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "Function", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<Function>> GetCachedListAsync()
        {
            var cacheKey = FunctionCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<Function>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }


        public async Task<List<Function>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(Function function)
        {
            await _repository.AddAsync(function);
            await _distributedCache.RemoveAsync(FunctionCacheKey.ListKey);
            return function.Id;
        }

        public async Task UpdateAsync(Function function)
        {
            await _repository.UpdateAsync(function);
            await _distributedCache.RemoveAsync(FunctionCacheKey.ListKey);
            await _distributedCache.RemoveAsync(FunctionCacheKey.GetKey(function.Id));
        }
    }
}