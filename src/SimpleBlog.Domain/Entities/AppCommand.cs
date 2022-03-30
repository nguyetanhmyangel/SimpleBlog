
using SimpleBlog.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Domain.Entities
{
    public class AppCommand : AuditEntity<int>
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}