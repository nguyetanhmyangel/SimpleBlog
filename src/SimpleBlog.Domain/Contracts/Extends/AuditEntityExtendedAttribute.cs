using SimpleBlog.Domain.Enums;

namespace SimpleBlog.Domain.Contracts.Extends
{
    public abstract class AuditEntityExtendedAttribute<TId, TEntityId, TEntity>
        : AuditEntity<TId>, IEntityAuditExtendedAttribute<TId, TEntityId, TEntity>
            where TEntity : IEntity<TEntityId>
    {
        /// <inheritdoc/>
        public TEntityId EntityId { get; set; }


        /// <summary>
        /// Extended attribute's related entity
        /// </summary>
        public virtual TEntity Entity { get; set; }

        /// <inheritdoc/>
        public EntityExtendedAttributeType Type { get; set; }

        /// <inheritdoc/>
        public string Key { get; set; }

        /// <inheritdoc/>
        public string? Text { get; set; }

        /// <inheritdoc/>
        public decimal? Decimal { get; set; }

        /// <inheritdoc/>
        public DateTime? DateTime { get; set; }

        /// <inheritdoc/>
        public string? Json { get; set; }

        /// <inheritdoc/>
        public string? ExternalId { get; set; }

        /// <inheritdoc/>
        public string? Group { get; set; }

        /// <inheritdoc/>
        public string? Description { get; set; }

        /// <inheritdoc/>
        public bool IsActive { get; set; } = true;
    }
}