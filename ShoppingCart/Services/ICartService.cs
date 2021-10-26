using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICartService
    {
        Task<CartDetails> GetCartDetails(int id);
        Task AddItemToCart(int cartId, CartItemRequest cartItemRequest);
        Task CancelCart(int cartId);

    }
}
