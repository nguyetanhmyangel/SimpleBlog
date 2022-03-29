using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Domain.Entities
{
    [Table("Comments")]
    public class Comment : AuditEntity<int>
    {
        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        [Required]
        public int KnowledgeId { get; set; }

        public virtual Knowledge Knowledge { get; set; }
    }
}