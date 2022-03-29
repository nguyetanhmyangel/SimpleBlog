using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlog.Domain.Abstractions;

namespace SimpleBlog.Domain.Entities
{
    [Table("AppPermissions")]
    public class AppPermission : AuditEntity<int>
    {
        //public AppPermission(string functionId, string roleId, string commandId)
        //{
        //    FunctionId = functionId;
        //    RoleId = roleId;
        //    CommandId = commandId;
        //}

        public int FunctionId { get; set; }

        public int RoleId { get; set; }

        public int AppCommandId { get; set; }

        public virtual Function Function { get; set; }

        public virtual AppCommand AppCommand { get; set; }
    }
}