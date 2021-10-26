using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICartService
    {
        Task<CartDetails> GetCartDetails(int id);
        Task AddItemToCart(CartItemRequest cartItemRequest);
        Task CancelCart(int cartId);

    }
}
