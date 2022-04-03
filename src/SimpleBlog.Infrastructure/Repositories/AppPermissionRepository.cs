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
    public class AppPermissionRepository : IAppPermissionRepository
    {
        private readonly IRepositoryAsync<AppPermission> _repository;
        private readonly IDistributedCache _distributedCache;

        public AppPermissionRepository(IDistributedCache distributedCache, IRepositoryAsync<AppPermission> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<AppPermission> AppPermissions => _repository.Entities;

        public async Task DeleteAsync(AppPermission appPermission)
        {
            await _repository.DeleteAsync(appPermission);
            await _distributedCache.RemoveAsync(AppPermissionCacheKey.ListKey);
            await _distributedCache.RemoveAsync(AppPermissionCacheKey.GetKey(appPermission.Id));
        }

        public async Task<AppPermission> GetByIdAsync(int appPermissionId)
        {
            return await _repository.Entities.Where(p => p.Id == appPermissionId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<AppPermission?> GetCachedByIdAsync(int appPermissionId)
        {
            var cacheKey = AppPermissionCacheKey.GetKey(appPermissionId);
            var list = await _distributedCache.GetAsync<AppPermission>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == appPermissionId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "AppPermission", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<AppPermission>> GetCachedListAsync()
        {
            var cacheKey = AppPermissionCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<AppPermission>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }

        public async Task<List<AppPermission>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(AppPermission appPermission)
        {
            await _repository.AddAsync(appPermission);
            await _distributedCache.RemoveAsync(AppPermissionCacheKey.ListKey);
            return appPermission.Id;
        }

        public async Task UpdateAsync(AppPermission appPermission)
        {
            await _repository.UpdateAsync(appPermission);
            await _distributedCache.RemoveAsync(AppPermissionCacheKey.ListKey);
            await _distributedCache.RemoveAsync(AppPermissionCacheKey.GetKey(appPermission.Id));
        }
    }
}