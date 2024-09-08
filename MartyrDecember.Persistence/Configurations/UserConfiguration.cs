using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartyrDecember.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "sony",
                     NormalizedUserName = "Sony",
                     Email = "sony@systemdotproject.com",
                     NormalizedEmail = "SONY@SYSTEMDOTPROJECT.COM",
                     EmailConfirmed = true,
                     PasswordHash = hasher.HashPassword(null, "Eka@3zal")
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "ashwal",
                     NormalizedUserName = "ashwal",
                     Email = "ashwal@systemdotproject.com",
                     NormalizedEmail = "ASHWAL@SYSTEMDOTPROJECT.COM",
                     EmailConfirmed = true,
                     PasswordHash = hasher.HashPassword(null, "Tito@Sadma")
                 }
            );
        }
    }
}
