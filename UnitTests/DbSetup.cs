using ShoppingCart;
using ShoppingCart.Models.Entity;
using ShoppingCart.Models.Enums;
using System;

namespace UnitTests
{
    public static class DbSetup
    {
        public const int SUBMITTED_CART_ID = 100;
        public const int DRAFT_CART_ID = 101;

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
                TimeCreated = DateTime.UtcNow
            });

            context.SaveChanges();
        }
    }
}
