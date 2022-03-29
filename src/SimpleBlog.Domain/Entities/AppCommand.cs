
using SimpleBlog.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Domain.Entities
{
    [Table("AppCommands")]
    public class AppCommand : AuditEntity<int>
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}