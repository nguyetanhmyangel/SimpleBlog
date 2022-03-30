using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        //public byte[] ProfilePicture { get; set; }
        public string ProfilePictureUrl { get; set; }

        public bool Active { get; set; } = false;

        [Required]
        public DateTime Dob { get; set; }

        public int? NumberOfMySpaces { get; set; }

        public int? NumberOfVotes { get; set; }

        public int? NumberOfReports { get; set; }
    }
}