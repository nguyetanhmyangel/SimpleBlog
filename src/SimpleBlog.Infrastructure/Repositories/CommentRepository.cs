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
    public class CommentRepository : ICommentRepository
    {
        private readonly IRepositoryAsync<Comment> _repository;
        private readonly IDistributedCache _distributedCache;

        public CommentRepository(IDistributedCache distributedCache, IRepositoryAsync<Comment> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Comment> Comments => _repository.Entities;

        public async Task DeleteAsync(Comment comment)
        {
            await _repository.DeleteAsync(comment);
            await _distributedCache.RemoveAsync(CommentCacheKey.ListKey);
            await _distributedCache.RemoveAsync(CommentCacheKey.GetKey(comment.Id));
        }

        public async Task<Comment> GetByIdAsync(int commentId)
        {
            return await _repository.Entities.Where(p => p.Id == commentId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Comment> GetCachedByIdAsync(int commentId)
        {
            var cacheKey = CommentCacheKey.GetKey(commentId);
            var list = await _distributedCache.GetAsync<Comment>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == commentId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "Comment", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<Comment>> GetCachedListAsync()
        {
            var cacheKey = CommentCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<Comment>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }


        public async Task<List<Comment>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(Comment Comment)
        {
            await _repository.AddAsync(Comment);
            await _distributedCache.RemoveAsync(CommentCacheKey.ListKey);
            return Comment.Id;
        }

        public async Task UpdateAsync(Comment Comment)
        {
            await _repository.UpdateAsync(Comment);
            await _distributedCache.RemoveAsync(CommentCacheKey.ListKey);
            await _distributedCache.RemoveAsync(CommentCacheKey.GetKey(Comment.Id));
        }
    }
}