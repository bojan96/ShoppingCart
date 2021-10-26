using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using ShoppingCart.Models.Entity;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingCartDbContext _dbContext;

        public CartService(IMapper mapper, ShoppingCartDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Task AddItemToCart(int cartId, CartItemRequest cartItemRequest)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CartDetails> GetCartDetails(int id)
        {
            Cart cart = await _dbContext.Carts.Include(cart => cart.CartItems).SingleOrDefaultAsync(cart => cart.Id == id);
            if (cart == null)
                return null;

            return _mapper.Map<CartDetails>(cart);
        }


    }
}
