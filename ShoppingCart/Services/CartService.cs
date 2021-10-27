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
        private readonly ICartProcessorService _cartProcessService;

        public CartService(IMapper mapper, ShoppingCartDbContext dbContext, ICartProcessorService cartProcessService)
            => (_mapper, _dbContext, _cartProcessService) = (mapper, dbContext, cartProcessService);
       
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

        public async Task CancelCart(int id)
        {
            Cart cart = await _dbContext.Carts.SingleOrDefaultAsync(cart => cart.Id == id);
            if (cart == null)
                throw new EntityNotFoundException(id);

            if (cart.Status == CartStatus.Submitted)
                throw new CartAlreadySubmittedException($"Cart with id {id} already submitted");

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

        public async Task<CartItemDetails> GetCartItemDetails(int cartItemId)
        {
            CartItem cartItem = await _dbContext.CartItems.SingleOrDefaultAsync(id => id.Id == cartItemId);
            if (cartItem == null)
                throw new EntityNotFoundException(cartItemId);

            return _mapper.Map<CartItemDetails>(cartItem);
        }

        public async Task SubmitCart(int id)
        {
            Cart cart = await _dbContext.Carts.SingleOrDefaultAsync(cart => cart.Id == id);
            if (cart == null)
                throw new EntityNotFoundException(id);

            if (cart.Status == CartStatus.Submitted)
                throw new CartAlreadySubmittedException("Cart already submitted");

            CartDetails cartDetails = _mapper.Map<CartDetails>(cart);
            await _cartProcessService.ProcessCart(cartDetails);
            cart.Status = CartStatus.Submitted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
