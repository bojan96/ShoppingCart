using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICartProcessorService
    {
        /// <summary>
        /// Process submitted cart
        /// </summary>
        /// <param name="cartDetails">Cart details to process</param>
        /// <returns>true if processing is succesful, false otherwise</returns>
        Task ProcessCart(CartDetails cartDetails);
    }
}
