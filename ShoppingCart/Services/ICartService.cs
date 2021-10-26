using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICartService
    {
        Task<CartDetails> GetCartDetails(int id);
        Task AddItemToCart(int cartId, CartItemRequest cartItemRequest);
        Task RemoveItemFromCart(int cartItemId);
        Task CancelCart(int cartId);
        Task<CartItemDetails> GetCartItemDetails(int cartItemid);
        Task SubmitCart(int id);
    }
}
