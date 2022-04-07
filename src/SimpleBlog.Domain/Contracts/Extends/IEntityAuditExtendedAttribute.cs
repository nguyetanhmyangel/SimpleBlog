namespace SimpleBlog.Domain.Contracts.Extends
{
    public interface IEntityAuditExtendedAttribute<TId, TEntityId, TEntity>
        : IEntityExtendedAttribute<TId, TEntityId, TEntity>, IAuditEntity<TId>
            where TEntity : IEntity<TEntityId>
    {
    }

    public interface IEntityAuditExtendedAttribute<TEntityId, TEntity>
        : IEntityExtendedAttribute<TEntityId, TEntity>, IAuditEntity
            where TEntity : IEntity<TEntityId>
    {
    }

    public interface IEntityAuditExtendedAttribute : IEntityExtendedAttribute, IAuditEntity
    {
    }
}