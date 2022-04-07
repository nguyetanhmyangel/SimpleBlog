using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Contracts;

namespace SimpleBlog.Domain.Entities.Catalog
{
    [Table("Votes")]
    public class Vote : AuditEntity<int>
    {
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}