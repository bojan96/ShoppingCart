using AutoMapper;
using ShoppingCart.Models;
using ShoppingCart.Models.Entity;

namespace ShoppingCart.AutoMapper
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<CartItem, CartItemShortDetails>();
            CreateMap<Cart, CartDetails>();
        }
    }
}
