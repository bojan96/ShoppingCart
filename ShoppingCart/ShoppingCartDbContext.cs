using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models.Entity;
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

    }
}
