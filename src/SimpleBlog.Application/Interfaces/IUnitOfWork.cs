using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}