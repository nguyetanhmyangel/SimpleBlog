using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}