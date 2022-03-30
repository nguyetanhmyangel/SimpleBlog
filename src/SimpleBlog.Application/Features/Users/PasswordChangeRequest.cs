namespace SimpleBlog.Application.Features.Users
{
    public class PasswordChangeRequest
    {
        public string UserId { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}