using ShoppingCart.Models;
using System.Threading.Tasks;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Services
{
    public interface ICartProcessorService
    {
        /// <summary>
        /// Process submitted cart
        /// </summary>
        /// <param name="cartDetails">Cart details to process</param>
        /// <returns>true if processing is succesful, false otherwise</returns>
        /// <exception cref="CartProcessFailedException"></exception>
        Task ProcessCart(CartDetails cartDetails);
    }
}
