using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }

        Task<List<Comment>> GetListAsync();

        Task<Comment> GetByIdAsync(int commentId);

        Task<List<Comment>> GetCachedListAsync();

        Task<Comment> GetCachedByIdAsync(int commentId);

        Task<int> AddAsync(Comment comment);

        Task UpdateAsync(Comment comment);

        Task DeleteAsync(Comment comment);
    }
}
