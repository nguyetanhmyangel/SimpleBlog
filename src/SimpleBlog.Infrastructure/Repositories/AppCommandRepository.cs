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
    public class AppCommandRepository : IAppCommandRepository
    {
        private readonly IRepositoryAsync<AppCommand> _repository;
        private readonly IDistributedCache _distributedCache;

        public AppCommandRepository(IDistributedCache distributedCache, IRepositoryAsync<AppCommand> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<AppCommand> AppCommands => _repository.Entities;

        public async Task DeleteAsync(AppCommand appCommand)
        {
            await _repository.DeleteAsync(appCommand);
            await _distributedCache.RemoveAsync(AppCommandCacheKey.ListKey);
            await _distributedCache.RemoveAsync(AppCommandCacheKey.GetKey(appCommand.Id));
        }

        public async Task<AppCommand> GetByIdAsync(int appCommandId)
        {
            return await _repository.Entities.Where(p => p.Id == appCommandId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<AppCommand?> GetCachedByIdAsync(int appCommandId)
        {
            var cacheKey = AppCommandCacheKey.GetKey(appCommandId);
            var list = await _distributedCache.GetAsync<AppCommand>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == appCommandId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "AppCommand", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<AppCommand>> GetCachedListAsync()
        {
            var cacheKey = AppCommandCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<AppCommand>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }

        public async Task<List<AppCommand>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(AppCommand appCommand)
        {
            await _repository.AddAsync(appCommand);
            await _distributedCache.RemoveAsync(AppCommandCacheKey.ListKey);
            return appCommand.Id;
        }

        public async Task UpdateAsync(AppCommand appCommand)
        {
            await _repository.UpdateAsync(appCommand);
            await _distributedCache.RemoveAsync(AppCommandCacheKey.ListKey);
            await _distributedCache.RemoveAsync(AppCommandCacheKey.GetKey(appCommand.Id));
        }
    }
}