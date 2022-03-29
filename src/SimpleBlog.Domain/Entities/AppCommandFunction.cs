using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Domain.Entities
{
    [Table("AppCommandFunctions")]
    public class AppCommandFunction : AuditEntity<int>
    {
        public int AppCommandId { get; set; }

        public int FunctionId { get; set; }

        public virtual AppCommand AppCommand { get; set; }

        public virtual Function Function { get; set; }
    }
}