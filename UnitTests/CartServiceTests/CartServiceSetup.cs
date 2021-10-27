using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart;
using ShoppingCart.AutoMapper;
using System;

namespace UnitTests.CartServiceTests
{
    public partial class CartServiceTests : IDisposable
    {
        private readonly IMapper _mapper;
        private readonly ShoppingCartDbContext _dbContext;

        public CartServiceTests()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile<CartMappingProfile>())
                .CreateMapper();
            _dbContext = CreateContext();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        private ShoppingCartDbContext CreateContext()
        {
            DbContextOptions<ShoppingCartDbContext> options = new DbContextOptionsBuilder<ShoppingCartDbContext>()
                .UseInMemoryDatabase("test")
                .Options;

            ShoppingCartDbContext context = new(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // Avoid using seed data from migrations
            DbSetup.Seed(context);
            return context;
        }
    }
}
