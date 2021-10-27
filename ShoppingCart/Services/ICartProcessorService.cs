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
        /// <exception cref="CartProcessFailedException">If cart processing fails</exception>
        Task ProcessCart(CartDetails cartDetails);
    }
}
