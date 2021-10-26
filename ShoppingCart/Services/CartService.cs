using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Exceptions;
using ShoppingCart.Models;
using ShoppingCart.Models.Entity;
using ShoppingCart.Models.Enums;
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

        public async Task AddItemToCart(int id, CartItemRequest cartItemRequest)
        {
            CartItem item = _mapper.Map<CartItem>(cartItemRequest);
            item.CreatedBy = "placeholder";
            item.TimeCreated = DateTime.UtcNow;

            Cart cart = await _dbContext
                .Carts
                .SingleOrDefaultAsync(cart => cart.Id == id);
            if (cart == null)
                throw new EntityNotFoundException(id);

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

        public async Task CancelCart(int cartId)
        {
            Cart cart = await _dbContext.Carts.SingleOrDefaultAsync(cart => cart.Id == cartId);
            if (cart == null)
                throw new EntityNotFoundException(cartId);

            cart.Status = CartStatus.Cancelled;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveItemFromCart(int cartItemId)
        {
            CartItem item = await _dbContext.CartItems.SingleOrDefaultAsync(item => item.Id == cartItemId);
            if (item == null)
                throw new EntityNotFoundException(cartItemId);

            _dbContext.CartItems.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
