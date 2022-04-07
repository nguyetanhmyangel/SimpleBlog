using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Contracts;

namespace SimpleBlog.Domain.Entities.Catalog
{
    [Table("Reports")]
    public class Report :AuditEntity<int>
    {
        public int KnowledgeId { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public bool IsProcessed { get; set; }

        public virtual Article Article { get; set; }
    }
}