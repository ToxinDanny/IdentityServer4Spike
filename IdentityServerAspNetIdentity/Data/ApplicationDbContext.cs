using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerAspNetIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasKey(e => e.Id);
            builder.Entity<ApplicationUser>()
                .Property(e => e.Id);    

            builder.Entity<ApplicationUser>()
                .Property(e => e.UserId)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();

            // builder.Entity<ApplicationUser>()
            //     .Property(e => e.RoleId)
            //     .IsRequired()
            //     .HasColumnType("int");

            builder.Entity<ApplicationUser>()
                .Property(e => e.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(256)");

            builder.Entity<ApplicationUser>()
                .Property(e => e.PasswordHash)
                .IsRequired()
                .HasColumnType("nvarchar(256)");

            builder.Entity<ApplicationUser>()
                .Property(e => e.Salt)
                .IsRequired()
                .HasColumnType("nvarchar(256)");    

            builder.Entity<ApplicationUser>()
                .Property(e => e.Email)
                .IsRequired()
                .HasColumnType("nvarchar(256)");

            builder.Entity<ApplicationUser>()
                .Property(e => e.VatCode)
                .IsRequired()
                .HasColumnType("nvarchar(256)");    

            builder.Entity<ApplicationUser>().HasOne(e => e.Role);

#region Ignore
            builder.Entity<ApplicationUser>().Ignore(e => e.NormalizedUserName);

            builder.Ignore<IdentityUserLogin<int>>();
            builder.Ignore<IdentityUserRole<int>>();
            builder.Ignore<IdentityUserToken<int>>();
            builder.Ignore<IdentityUserClaim<int>>();
            builder.Ignore<IdentityRoleClaim<int>>();
#endregion
        }
    }
}
