using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Contracts;

namespace SimpleBlog.Domain.Entities.Catalog
{
    [Table("Labels")]
    public class Label : AuditEntity<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}