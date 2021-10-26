using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICartService
    {
        Task<CartDetails> GetCartDetails(int id);
        Task AddItemToCart(int id, CartItemRequest cartItemRequest);
        Task RemoveItemFromCart(int cartItemId);
        Task CancelCart(int id);
        Task<CartItemDetails> GetCartItemDetails(int cartItemid);
        Task SubmitCart(int id);
    }
}
