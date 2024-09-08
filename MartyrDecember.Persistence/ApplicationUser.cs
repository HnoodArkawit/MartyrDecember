using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MartyrDecember.Persistence
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        //public byte[] ProfilePicture { get; set; }
    }
}