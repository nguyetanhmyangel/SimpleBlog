using SimpleBlog.Domain.Contracts.Extends;
using SimpleBlog.Domain.Enums;

namespace SimpleBlog.Application.Features.ExtendedAttributes.Queries.GetById
{
    public class GetExtendedAttributeByIdResponse<TId, TEntityId> : IEntityAuditExtendedAttribute
    {
        public TId Id { get; set; }
        public TEntityId EntityId { get; set; }

        public EntityExtendedAttributeType Type { get; set; }

        public string Key { get; set; }

        public string? Text { get; set; }

        public decimal? Decimal { get; set; }

        public DateTime? DateTime { get; set; }

        public string? Json { get; set; }

        public string? ExternalId { get; set; }

        public string? Group { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}