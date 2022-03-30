using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Domain.Entities
{
    [Table("LabelKnowledge")]
    public class LabelArticle : AuditEntity<int>
    {
        public int ArticleId { get; set; }

        public int LabelId { get; set; }

        public virtual Article Article{ get; set; }

        public virtual Label Label { get; set; }
    }
}