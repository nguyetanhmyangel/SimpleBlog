
namespace SimpleBlog.Domain.Contracts
{
    public interface IAuditEntity<TId> : IAuditEntity, IEntity<TId>
    {
    }

    public interface IAuditEntity : IEntity
    {
        string CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        string LastModifiedBy { get; set; }

        DateTime? LastModifiedOn { get; set; }
    }
}