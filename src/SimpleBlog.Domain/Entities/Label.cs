using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Domain.Entities
{
    [Table("Labels")]
    public class Label : AuditEntity<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}