using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Infrastructure.CacheKeys;

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

        public async Task<AppCommandFunction> GetCachedByIdAsync(int productId)
        {
            var cacheKey = AppCommandFunctionCacheKey.GetKey(productId);
            var product = await _distributedCache.GetAsync<AppCommandFunction, CancellationToken token = default> (cacheKey);
            if (product == null)
            {
                product = await GetByIdAsync(productId);
                Throw.Exception.IfNull(product, "Product", "No Product Found");
                await _distributedCache.SetAsync(cacheKey, product);
            }
            return product;
        }

        public async Task<List<Product>> GetCachedListAsync()
        {
            string cacheKey = ProductCacheKeys.ListKey;
            var productList = await _distributedCache.GetAsync<List<Product>>(cacheKey);
            if (productList == null)
            {
                productList = await _productRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, productList);
            }
            return productList;
        }

        public IQueryable<AppCommandFunction> CommandFunctions { get; }

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