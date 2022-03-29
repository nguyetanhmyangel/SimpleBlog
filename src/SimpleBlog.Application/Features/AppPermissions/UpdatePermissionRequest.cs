using System.Collections.Generic;

namespace SimpleBlog.Application.Features.AppPermissions
{
    public class UpdatePermissionRequest
    {
        public List<PermissionResponse> Permissions { get; set; } = new List<PermissionResponse>();
    }
}