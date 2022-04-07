using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Contracts;

namespace SimpleBlog.Domain.Entities.Catalog
{
    [Table("Comments")]
    public class Comment : AuditEntity<int>
    {
        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}