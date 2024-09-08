using MartyrDecember.Damain;
using MartyrDecember.Domain;
using MartyrDecember.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MartyrDecember.Persistence
{
    public class MartyrDecemberDbContext : IdentityDbContext<ApplicationUser>
    {
        public MartyrDecemberDbContext(DbContextOptions<MartyrDecemberDbContext> options)
   : base(options)
        {
        }

        public DbSet<MarPic> MarPics { get; set; }
        public DbSet<MarVid> MarVids { get; set; }
        public DbSet<SayMartyrs> SayMartyrs { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());



            //modelBuilder.Entity<MarPic>().Property(x => x.MarPicId).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<MarVid>().Property(x => x.MarVidId).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<ProfilePicture>().Property(x => x.ProfileId).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<SayMartyrs>().Property(x => x.SayId).HasDefaultValueSql("NEWID()");


            //modelBuilder.Entity<MarPic>().HasData(new MarPic
            //{
            //    MarPicId = Guid.NewGuid(),
            //    MartyrName = "Introduction to CQRS and Mediator Patterns",
            //    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat",
            //    DateMartyr = DateTime.Now,
            //    //ImageUrl = "https://api.khalidessaadani.com/uploads/articles_bg.jpg",
            //});

            //modelBuilder.Entity<MarVid>().HasData(new MarVid
            //{
            //    MarVidId = Guid.NewGuid(),
            //    MartyrName = "Introduction to CQRS and Mediator Patterns",
            //    Description = "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat",
            //    //VideoUrl = "https://api.khalidessaadani.com/uploads/articles_bg.mp4",

            //});

            //modelBuilder.Entity<ProfilePicture>().HasData(new ProfilePicture
            //{
            //    ProfileId = Guid.NewGuid(),
            //    ImageUrl = "2170"

            //});
            //modelBuilder.Entity<SayMartyrs>().HasData(new SayMartyrs
            //{
            //    SayId = Guid.NewGuid(),
            //    MartyrName = "Introduction to CQRS and Mediator Patterns",
            //    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat",
            //    //ImageUrl = "https://api.khalidessaadani.com/uploads/articles_bg.jpg",
            //});
        }
    }
}