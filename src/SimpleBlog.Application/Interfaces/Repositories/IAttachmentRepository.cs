using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IAttachmentRepository
    {
        IQueryable<Attachment> Attachments { get; }

        Task<List<Attachment>> GetListAsync();

        Task<Attachment> GetByIdAsync(int attachmentId);

        Task<List<Attachment>> GetCachedListAsync();

        Task<Attachment> GetCachedByIdAsync(int attachmentId);

        Task<int> AddAsync(Attachment attachment);

        Task UpdateAsync(Attachment attachment);

        Task DeleteAsync(Attachment attachment);
    }
}
