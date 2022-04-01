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
    public class ArticleRepository : IArticleRepository
    {
        private readonly IRepositoryAsync<Article> _repository;
        private readonly IDistributedCache _distributedCache;

        public ArticleRepository(IDistributedCache distributedCache, IRepositoryAsync<Article> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Article> Articles => _repository.Entities;

        public async Task DeleteAsync(Article Article)
        {
            await _repository.DeleteAsync(Article);
            await _distributedCache.RemoveAsync(ArticleCacheKey.ListKey);
            await _distributedCache.RemoveAsync(ArticleCacheKey.GetKey(Article.Id));
        }

        public async Task<Article> GetByIdAsync(int articleId)
        {
            return await _repository.Entities.Where(p => p.Id == articleId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Article> GetCachedByIdAsync(int articleId)
        {
            var cacheKey = ArticleCacheKey.GetKey(articleId);
            var list = await _distributedCache.GetAsync<Article>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == articleId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "Article", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<Article>> GetCachedListAsync()
        {
            var cacheKey = ArticleCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<Article>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }


        public async Task<List<Article>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(Article article)
        {
            await _repository.AddAsync(article);
            await _distributedCache.RemoveAsync(ArticleCacheKey.ListKey);
            return article.Id;
        }

        public async Task UpdateAsync(Article article)
        {
            await _repository.UpdateAsync(article);
            await _distributedCache.RemoveAsync(ArticleCacheKey.ListKey);
            await _distributedCache.RemoveAsync(ArticleCacheKey.GetKey(article.Id));
        }
    }
}