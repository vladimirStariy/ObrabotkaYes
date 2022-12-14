using Microsoft.EntityFrameworkCore;
using ObrabotkaYes.Domain.Entity;
using ObrabotkaYes.Domain.Enum;
using ObrabotkaYes.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.DataAcessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Profile>? Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasData(new User
                {
                    User_ID = 1,
                    Login = "admin",
                    Password = HashPasswordHelper.HashPassword("admin"),
                    Role = Role.Admin
                });

                builder.ToTable("Users").HasKey(x => x.User_ID);

                builder.Property(x => x.User_ID).ValueGeneratedOnAdd();
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Login).HasMaxLength(50).IsRequired();

                builder.HasOne(x => x.Profile)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.User_ID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.Profile_ID);

                builder.Property(x => x.Profile_ID).ValueGeneratedOnAdd();

                builder.Property(x => x.Login);
            });
        }
    }
}
