using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken);

        //Commit And RemoveCache
        Task<int> CommitAsync(CancellationToken cancellationToken, params string[] cacheKeys);
        
        Task Rollback();
    }
}