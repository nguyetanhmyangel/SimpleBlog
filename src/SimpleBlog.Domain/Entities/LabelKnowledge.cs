using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Domain.Entities
{
    [Table("LabelKnowledge")]
    public class LabelKnowledge : AuditEntity<int>
    {
        public int KnowledgeId { get; set; }

        public int LabelId { get; set; }

        public virtual Knowledge Knowledge{ get; set; }

        public virtual Label Label { get; set; }
    }
}