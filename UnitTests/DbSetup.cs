using ShoppingCart;
using ShoppingCart.Models.Entity;
using ShoppingCart.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public static class DbSetup
    {
        public const int SUBMITTED_CART_ID = 100;
        public const int DRAFT_CART_ID = 101;
        public const int CART_ITEM_ID = 100;
        public const int NON_EXISTENT_CART_ITEM_ID = 2000;
        public const int NON_EXISTENT_CART_ID = 2000;

        public static void Seed(ShoppingCartDbContext context)
        {
            context.Carts.AddRange(new Cart
            {
                Id = SUBMITTED_CART_ID,
                Status = CartStatus.Submitted,
                CreatedBy = "user",
                TimeCreated = DateTime.UtcNow
            },
            new Cart
            {
                Id = DRAFT_CART_ID,
                Status = CartStatus.Draft,
                CreatedBy = "user",
                TimeCreated = DateTime.UtcNow,
                CartItems = Enumerable.Range(0, 2)
                .Select(i => new CartItem
                {
                    // Avoid same ids as data created in migrations
                    Id = CART_ITEM_ID + i,
                    CartId = DRAFT_CART_ID,
                    CreatedBy = "user",
                    Description = $"Description{i}",
                    Name = $"Name{i}",
                    TimeCreated = DateTime.UtcNow
                }).ToList()
            });

            context.SaveChanges();
        }
    }
}
