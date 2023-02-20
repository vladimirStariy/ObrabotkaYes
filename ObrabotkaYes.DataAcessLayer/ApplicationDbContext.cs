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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderPicture>? OrderPictures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }

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

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders").HasKey(x => x.Order_ID);
                builder.Property(x => x.Order_ID).ValueGeneratedOnAdd();
                builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
                builder.Property(x => x.Description).IsRequired();
                builder.Property(x => x.Phone).HasMaxLength(50).IsRequired();
                builder.HasMany(x => x.Categories)
                       .WithMany(x => x.Orders)
                       .UsingEntity(x => x.ToTable("OrderCategories"));
            });

            modelBuilder.Entity<OrderPicture>(builder =>
            {
                builder.ToTable("OrderPictures").HasKey(x => x.OrderPicture_ID);
                builder.Property(x => x.OrderPicture_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.ToTable("Categories").HasKey(x => x.Category_ID);
                builder.Property(x => x.Category_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<OrderType>(builder =>
            {
                builder.ToTable("OrderTypes").HasKey(x => x.Type_ID);
                builder.Property(x => x.Type_ID).ValueGeneratedOnAdd();
            });

        }
    }
}
