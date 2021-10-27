using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Authentication;
using ShoppingCart.Filters;
using ShoppingCart.Models;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ServiceExceptionFilter))]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
            => _cartService = cartService;
        

        [HttpGet("{id}")]
        [Authorize(Policy = AuthPolicies.VIEWER)]
        public async Task<ActionResult<CartDetails>> GetCartOverview(int id)
        {
            CartDetails details = await _cartService.GetCartDetails(id);
            return details;
        }

        [HttpPost("{id}/item")]
        [Authorize(Policy = AuthPolicies.STANDARD)]
        public async Task<ActionResult> AddItemToCart(int id, [FromBody]CartItemRequest item)
        {
            string userId = User.Claims.First(cl => cl.Type == ClaimTypes.NameIdentifier).Value;
            await _cartService.AddItemToCart(id, userId, item);
            return NoContent();
        }

        [HttpDelete("item/{id}")]
        [Authorize(Policy = AuthPolicies.STANDARD)]
        public async Task<ActionResult> RemoveItemFromCart(int id)
        {
            await _cartService.RemoveItemFromCart(id);
            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        [Authorize(Policy = AuthPolicies.STANDARD)]
        public async Task<ActionResult> CancelCart(int id)
        {
            await _cartService.CancelCart(id);
            return NoContent();
        }

        [HttpGet("item/{id}")]
        [Authorize(Policy = AuthPolicies.VIEWER)]
        public async Task<ActionResult> GetCartItemDetails(int id)
        {
            CartItemDetails cartItem = await _cartService.GetCartItemDetails(id);
            return Ok(cartItem);
        }

        [HttpPost("{id}/submit")]
        [Authorize(Policy = AuthPolicies.STANDARD)]
        public async Task<ActionResult> SubmitCart(int id)
        {
            await _cartService.SubmitCart(id);
            return NoContent();
        }
    }
}
