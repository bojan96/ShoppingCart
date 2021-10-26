using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class CartItemRequest
    {
        public int CartId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
