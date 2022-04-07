using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Contracts;

namespace SimpleBlog.Domain.Entities.Catalog
{
    [Table("LabelArticles")]
    public class LabelArticle : AuditEntity<int>
    {
        public int ArticleId { get; set; }

        public int LabelId { get; set; }

        public virtual Article Article{ get; set; }

        public virtual Label Label { get; set; }
    }
}