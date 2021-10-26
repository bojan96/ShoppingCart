using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Exceptions;
using ShoppingCart.Models;
using ShoppingCart.Models.Entity;
using System;
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

        public async Task AddItemToCart(CartItemRequest cartItemRequest)
        {
            int cartId = cartItemRequest.CartId;
            CartItem item = _mapper.Map<CartItem>(cartItemRequest);
            item.CreatedBy = "placeholder";
            item.TimeCreated = DateTime.UtcNow;

            Cart cart = await _dbContext
                .Carts
                .SingleOrDefaultAsync(cart => cart.Id == cartId);
            if (cart == null)
                throw new EntityNotFoundException(cartId);

            cart.CartItems.Add(item);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<CartDetails> GetCartDetails(int id)
        {
            Cart cart = await _dbContext
                .Carts
                .Include(cart => cart.CartItems)
                .SingleOrDefaultAsync(cart => cart.Id == id);
            if (cart == null)
                throw new EntityNotFoundException(id);

            return _mapper.Map<CartDetails>(cart);
        }


    }
}
