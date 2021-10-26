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
                CreatedBy = "test",
                TimeCreated = createTime
            });

            IEnumerable<CartItem> items = Enumerable
                .Range(1, 5)
                .Select(count => new CartItem
            {
                Id = count,
                CartId = 1,
                TimeCreated = createTime.AddDays(count),
                Name = $"Name{count}",
                Description = $"Description{count}",
                CreatedBy = "test"
            });

            modelBuilder.Entity<CartItem>().HasData(items);
        }

    }
}
