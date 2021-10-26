using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetails>> GetCartOverview(int id)
        {
            CartDetails details = await _cartService.GetCartDetails(id);
            return details != null ? details : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddItemToCart([FromBody]CartItemRequest item)
        {
            await _cartService.AddItemToCart(item);
            return NoContent();
        }
    }
}
