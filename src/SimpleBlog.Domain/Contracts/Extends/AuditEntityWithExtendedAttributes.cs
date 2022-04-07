namespace SimpleBlog.Domain.Contracts.Extends
{
    public sealed class AuditEntityWithExtendedAttributes<TId, TEntityId, TEntity, TExtendedAttribute> 
        : AuditEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>
            where TEntity : IEntity<TEntityId>
    {
        public ICollection<TExtendedAttribute> ExtendedAttributes { get; set; }

        public AuditEntityWithExtendedAttributes()
        {
            ExtendedAttributes = new HashSet<TExtendedAttribute>();
        }
    }
}