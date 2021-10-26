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
            return details;
        }

        [HttpPost("{id}/item")]
        public async Task<ActionResult> AddItemToCart(int id, [FromBody]CartItemRequest item)
        {
            await _cartService.AddItemToCart(id, item);
            return NoContent();
        }

        [HttpDelete("item/{id}")]
        public async Task<ActionResult> RemoveItemFromCart(int id)
        {
            await _cartService.RemoveItemFromCart(id);
            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        public async Task<ActionResult> CancelCart(int id)
        {
            await _cartService.CancelCart(id);
            return NoContent();
        }

        [HttpGet("item/{id}")]
        public async Task<ActionResult> GetCartItemDetails(int id)
        {
            CartItemDetails cartItem = await _cartService.GetCartItemDetails(id);
            return Ok(cartItem);
        }
    }
}
