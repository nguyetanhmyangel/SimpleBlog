namespace SimpleBlog.Application.Features.AppPermissions
{
    public class PermissionScreenResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int ParentId { get; set; }

        public bool HasCreate { get; set; }

        public bool HasUpdate { get; set; }

        public bool HasDelete { get; set; }

        public bool HasView { get; set; }

        public bool HasApprove { get; set; }
    }
}