using SimpleBlog.Domain.Contracts;
using SimpleBlog.Domain.Contracts.Extends;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IExtendedAttributeUnitOfWork<TId, TEntityId, TEntity> : IDisposable where TEntity : AuditEntity<TEntityId>
    {
        IRepositoryAsync<T, TId> Repository<T>() where T : AuditEntityExtendedAttribute<TId, TEntityId, TEntity>;

        Task<int> Commit(CancellationToken cancellationToken);

        Task<int> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        Task Rollback();
    }
}