using Microsoft.EntityFrameworkCore;
using ShoppingCart.Exceptions;
using ShoppingCart.Models;
using ShoppingCart.Models.Entity;
using ShoppingCart.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.CartServiceTests
{
    public partial class CartServiceTests
    {
        [Fact]
        public async Task GetCartOverview()
        {
            Cart cart = await _dbContext.Carts.SingleAsync(c => c.Id == DbSetup.DRAFT_CART_ID);
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());
            CartDetails details = await service.GetCartDetails(DbSetup.DRAFT_CART_ID);

            Assert.Equal(cart.Id, details.Id);
            Assert.Equal(cart.Status, details.Status);
            Assert.Equal(cart.TimeCreated, details.TimeCreated);
            Assert.Equal(cart.CreatedBy, details.CreatedBy);
            Assert.Equal(cart.TimeUpdated, details.TimeUpdated);
            Assert.Equal(cart.CartItems.Count, details.CartItems.Count);
        }

        [Fact]
        public async Task GetCartOverviewDoesNotExists()
        {
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());

            await Assert.ThrowsAsync<EntityNotFoundException>(async ()
                => await service.GetCartDetails(DbSetup.NON_EXISTENT_CART_ID));
        }

        [Fact]
        public async Task CancelCart()
        {
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());
            await service.CancelCart(DbSetup.DRAFT_CART_ID);
        }

        [Fact]
        public async Task CancelCartAlreadySubmitted()
        {
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());
            await Assert.ThrowsAsync<CartAlreadySubmittedException>(async ()
               => await service.CancelCart(DbSetup.SUBMITTED_CART_ID));
        }

        [Fact]
        public async Task GetCartItemDetails()
        {
            CartItem item = await _dbContext.CartItems.SingleAsync(item => item.Id == DbSetup.CART_ITEM_ID);
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());
            CartItemDetails details = await service.GetCartItemDetails(DbSetup.CART_ITEM_ID);

            Assert.Equal(item.Id, details.Id);
            Assert.Equal(item.Name, details.Name);
            Assert.Equal(item.Description, details.Description);
            Assert.Equal(item.TimeCreated, details.TimeCreated);
            Assert.Equal(item.CreatedBy, details.CreatedBy);
            Assert.Equal(item.TimeUpdated, details.TimeUpdated);
        }

        [Fact]
        public async Task GetCartItemDetailsDoesNotExists()
        {
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());

            await Assert.ThrowsAsync<EntityNotFoundException>(async ()
                => await service.GetCartItemDetails(DbSetup.NON_EXISTENT_CART_ITEM_ID));
        }

        [Fact]
        public async Task AddItemToCart()
        {
            async Task<int> GetCartItemCount()
                => await _dbContext.CartItems.Where(item => item.CartId == DbSetup.DRAFT_CART_ID).CountAsync();
            int expectedItemCount = 1 + await GetCartItemCount();
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());
            await service.AddItemToCart(DbSetup.DRAFT_CART_ID, new CartItemRequest
            {
                Name = "Test name",
                Description = "Test description"
            });

            Assert.Equal(expectedItemCount, await GetCartItemCount());
        }

        [Fact]
        public async Task AddItemToCartDoesNotExists()
        {
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());

            await Assert.ThrowsAsync<EntityNotFoundException>(async () 
                => await service.AddItemToCart(DbSetup.NON_EXISTENT_CART_ID, 
                new CartItemRequest
                {
                    Name = "Test name",
                    Description = "Test description"
                }));
        }

        [Fact]
        public async Task RemoveItemFromCart()
        {
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());
            await service.RemoveItemFromCart(DbSetup.CART_ITEM_ID);
            bool exists = await _dbContext.CartItems.AnyAsync(cart => cart.Id == DbSetup.CART_ITEM_ID);
            Assert.False(exists);
        }

        [Fact]
        public async Task RemoveItemFromCartDoesNotExists()
        {
            ICartService service = new CartService(_mapper, _dbContext, GetAvailableProcessorService());
            await Assert.ThrowsAsync<EntityNotFoundException>(async () 
                => await service.RemoveItemFromCart(DbSetup.NON_EXISTENT_CART_ITEM_ID));
        }
    }
}
