using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Context
{
    public class ShopContext:IdentityDbContext<ShopUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            List<Product> a = new List<Product>();

            a.Add(new Product() { Id = 1, Name = "Test" });
            builder.Entity<Product>().HasData(a);


            base.OnModelCreating(builder);
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
         //   Database.EnsureCreated();
        }

    }
}
