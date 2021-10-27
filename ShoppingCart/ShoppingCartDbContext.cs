using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models.Entity;
using ShoppingCart.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class ShoppingCartDbContext : DbContext
    {

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            DateTime createTime = new(2021, 1, 1, 10, 10, 10, DateTimeKind.Utc);
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 1,
                Status = CartStatus.Draft,
                CreatedBy = "auth0|617946b7ed3a290068b82013",
                TimeCreated = createTime
            });

            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 2,
                Status = CartStatus.Submitted,
                CreatedBy = "auth0|6179475e1c278900683507fd",
                TimeCreated = createTime
            });

            IEnumerable<CartItem> draftItems = Enumerable
                .Range(1, 5)
                .Select(count => new CartItem
            {
                Id = count,
                CartId = 1,
                TimeCreated = createTime.AddDays(count),
                Name = $"Name{count}",
                Description = $"Description{count}",
                CreatedBy = "auth0|617946b7ed3a290068b82013"
                });

            IEnumerable<CartItem> submittedItems = Enumerable
                .Range(6, 5)
                .Select(count => new CartItem
                {
                    Id = count,
                    CartId = 2,
                    TimeCreated = createTime.AddDays(count),
                    Name = $"Name{count}",
                    Description = $"Description{count}",
                    CreatedBy = "auth0|6179475e1c278900683507fd"
                });

            modelBuilder.Entity<CartItem>().HasData(draftItems);
            modelBuilder.Entity<CartItem>().HasData(submittedItems);
        }

    }
}
