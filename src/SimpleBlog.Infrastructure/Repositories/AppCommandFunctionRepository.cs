using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities;

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

        public async Task DeleteAsync(AppCommandFunction AppCommandFunction)
        {
            await _repository.DeleteAsync(AppCommandFunction);
            await _distributedCache.RemoveAsync(CacheKeys.AppCommandFunctionCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.AppCommandFunctionCacheKeys.GetKey(AppCommandFunction.Id));
        }

        public async Task<AppCommandFunction> GetByIdAsync(int AppCommandFunctionId)
        {
            return await _repository.Entities.Where(p => p.Id == AppCommandFunctionId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<List<AppCommandFunction>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(AppCommandFunction AppCommandFunction)
        {
            await _repository.AddAsync(AppCommandFunction);
            await _distributedCache.RemoveAsync(CacheKeys.AppCommandFunctionCacheKeys.ListKey);
            return AppCommandFunction.Id;
        }

        public async Task UpdateAsync(AppCommandFunction AppCommandFunction)
        {
            await _repository.UpdateAsync(AppCommandFunction);
            await _distributedCache.RemoveAsync(CacheKeys.AppCommandFunctionCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.AppCommandFunctionCacheKeys.GetKey(AppCommandFunction.Id));
        }
    }
}