using System;

namespace SimpleBlog.Application.Features.AppPermissions
{
    public class PermissionResponse
    {
        public int FunctionId { get; set; }

        public Guid RoleId { get; set; }

        public int CommandId { get; set; }
    }
}