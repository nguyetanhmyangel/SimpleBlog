#nullable enable
namespace SimpleBlog.Domain.Contracts
{
    public abstract class AuditEntity<TId> : IAuditEntity<TId>
    {
        public TId? Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}