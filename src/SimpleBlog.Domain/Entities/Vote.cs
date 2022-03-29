using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Domain.Entities
{
    [Table("Votes")]
    public class Vote : AuditEntity<int>
    {
        public int KnowledgeId { get; set; }

        public virtual Knowledge Knowledge { get; set; }
    }
}