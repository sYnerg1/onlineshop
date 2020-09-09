using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Context
{
    public class ShopContext : IdentityDbContext<ShopUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            List<Product> products = new List<Product>()
            {
                new Product()
            {
                Id = 1,
                Name = "Meat",
                Price = 12.3M,
                Amount = 24
            },
            new Product()
            {
                Id = 2,
                Name = "Water",
                Price = 4.5M,
                Amount = 24
            },
            new Product()
            {
                Id = 3,
                Name = "Bread",
                Price = 9M,
                Amount = 24
            },
            new Product()
            {
                Id = 4,
                Name = "Cake",
                Price = 2.41M,
                Amount = 24
            },
            new Product()
            {
                Id = 5,
                Name = "Bottle",
                Price = 31.3M,
                Amount = 2
            } };

            builder.Entity<Product>()
                .HasData(products);

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Id = "admin-role-id",
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                },
                new IdentityRole
                {
                    Id = "golduser-role-id",
                    Name = "GoldUser",
                    NormalizedName = "GOLDUSER".ToUpper()
                },
                new IdentityRole
                {
                    Id = "user-role-id",
                    Name = "User",
                    NormalizedName = "USER".ToUpper()
                });


            var hasher = new PasswordHasher<ShopUser>();


            builder.Entity<ShopCart>()
                .HasData(new ShopCart
                {
                    Id = 33
                },
                new ShopCart
                {
                    Id = 34
                });


            builder.Entity<ShopUser>(b =>
        {
            b.HasData(new ShopUser()
            {
                Id = "admin-id",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "adminpass"),
                AccessFailedCount = 10,
                ShopCartId = 33
            },
            new ShopUser()
            {
                Id = "golduser-id",
                UserName = "golduser",
                NormalizedUserName = "GOLDUSER",
                PasswordHash = hasher.HashPassword(null, "goldpass"),
                AccessFailedCount = 10,
                ShopCartId = 34
            });

        });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "admin-role-id",
                    UserId = "admin-id"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "golduser-role-id",
                    UserId = "golduser-id"
                });



            base.OnModelCreating(builder);
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            //   Database.EnsureCreated();
        }

    }
}
