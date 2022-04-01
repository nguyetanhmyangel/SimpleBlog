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
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly IRepositoryAsync<Attachment> _repository;
        private readonly IDistributedCache _distributedCache;

        public AttachmentRepository(IDistributedCache distributedCache, IRepositoryAsync<Attachment> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Attachment> Attachments => _repository.Entities;

        public async Task DeleteAsync(Attachment attachment)
        {
            await _repository.DeleteAsync(attachment);
            await _distributedCache.RemoveAsync(AttachmentCacheKey.ListKey);
            await _distributedCache.RemoveAsync(AttachmentCacheKey.GetKey(attachment.Id));
        }

        public async Task<Attachment> GetByIdAsync(int attachmentId)
        {
            return await _repository.Entities.Where(p => p.Id == attachmentId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Attachment> GetCachedByIdAsync(int attachmentId)
        {
            var cacheKey = AttachmentCacheKey.GetKey(attachmentId);
            var list = await _distributedCache.GetAsync<Attachment>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == attachmentId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "Attachment", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<Attachment>> GetCachedListAsync()
        {
            var cacheKey = AttachmentCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<Attachment>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }

        public async Task<List<Attachment>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(Attachment attachment)
        {
            await _repository.AddAsync(attachment);
            await _distributedCache.RemoveAsync(AttachmentCacheKey.ListKey);
            return attachment.Id;
        }

        public async Task UpdateAsync(Attachment attachment)
        {
            await _repository.UpdateAsync(attachment);
            await _distributedCache.RemoveAsync(AttachmentCacheKey.ListKey);
            await _distributedCache.RemoveAsync(AttachmentCacheKey.GetKey(attachment.Id));
        }
    }
}