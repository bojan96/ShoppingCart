using ShoppingCart.Exceptions;
using ShoppingCart.Models;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    /// <summary>
    /// Placeholder implementation
    /// </summary>
    public class CartProcessorService : ICartProcessorService
    {
        private static readonly Random random = new();

        public async Task ProcessCart(CartDetails cartDetails)
        {
            await Process(cartDetails);

            // 20% chance that processing fails
            if (random.NextDouble() < 0.2)
                throw new CartProcessFailedException("Cart processing service unavailable");
        }

        private async Task Process(CartDetails details)
        {
            // TODO: Data preparation and sending goes here

            // Simulate processing time delay
            await Task.Delay(random.Next(1000, 2000));
        }
    }
}
