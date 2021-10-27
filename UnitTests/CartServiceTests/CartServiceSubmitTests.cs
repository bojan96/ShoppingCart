using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using ShoppingCart;
using ShoppingCart.AutoMapper;
using ShoppingCart.Exceptions;
using ShoppingCart.Models;
using ShoppingCart.Models.Entity;
using ShoppingCart.Models.Enums;
using ShoppingCart.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.CartServiceTests
{
    public partial class CartServiceTests
    {
        [Fact]
        public async Task SubmitCartSuccesfully()
        {
            Mock<ICartProcessorService> cartProcessorMock = new();
            cartProcessorMock
                .Setup(service => service.ProcessCart(It.IsAny<CartDetails>()))
                .Returns(Task.CompletedTask);

            ICartService service = new CartService(_mapper, _dbContext, cartProcessorMock.Object);

            await service.SubmitCart(DbSetup.DRAFT_CART_ID);
            Cart cart = await _dbContext.Carts.SingleAsync(cart => cart.Id == DbSetup.DRAFT_CART_ID);

            Assert.Equal(CartStatus.Submitted, cart.Status);
            cartProcessorMock.Verify(cartProcessor => cartProcessor.ProcessCart(It.Is<CartDetails>(details => 
            details.Id == cart.Id && 
            details.TimeCreated == cart.TimeCreated && 
            details.TimeUpdated == cart.TimeUpdated && 
            details.CreatedBy == cart.CreatedBy)), Times.Once);
        }

        [Fact]
        public async Task ProcessorServiceUnavaliable()
        {
            const int cartId = DbSetup.DRAFT_CART_ID;
            Mock<ICartProcessorService> cartProcessorMock = new();
            cartProcessorMock
                .Setup(service => service.ProcessCart(It.IsAny<CartDetails>()))
                .ThrowsAsync(new CartProcessFailedException("Service unavailable"));

            ICartService service = new CartService(_mapper, _dbContext, cartProcessorMock.Object);
            await Assert.ThrowsAsync<CartProcessFailedException>(async () 
                => await service.SubmitCart(cartId));

            Cart cart = await _dbContext.Carts.SingleAsync(cart => cart.Id == cartId);
            Assert.NotEqual(CartStatus.Submitted, cart.Status);
            cartProcessorMock.Verify(cartProcessor => cartProcessor.ProcessCart(It.IsAny<CartDetails>()), Times.Once);
        }

        [Fact]
        public async Task CartAlreadySubmitted()
        {
            Mock<ICartProcessorService> cartProcessorMock = new();
            cartProcessorMock
                .Setup(service => service.ProcessCart(It.IsAny<CartDetails>()))
                .Returns(Task.CompletedTask);

            ICartService service = new CartService(_mapper, _dbContext, cartProcessorMock.Object);

            await Assert.ThrowsAsync<CartAlreadySubmittedException>(async () 
                => await service.SubmitCart(DbSetup.SUBMITTED_CART_ID));
            cartProcessorMock.Verify(cartProcessor => cartProcessor.ProcessCart(It.IsAny<CartDetails>()), Times.Never);
        }

        [Fact]
        public async Task CartDoesNotExists()
        {
            const int cartId = 2000;
            Mock<ICartProcessorService> cartProcessorMock = new();
            cartProcessorMock
                .Setup(service => service.ProcessCart(It.IsAny<CartDetails>()))
                .Returns(Task.CompletedTask);

            ICartService service = new CartService(_mapper, _dbContext, cartProcessorMock.Object);

            await Assert.ThrowsAsync<EntityNotFoundException>(async ()
                => await service.SubmitCart(cartId));
            cartProcessorMock.Verify(cartProcessor => cartProcessor.ProcessCart(It.IsAny<CartDetails>()), Times.Never);
        }

    }
}
