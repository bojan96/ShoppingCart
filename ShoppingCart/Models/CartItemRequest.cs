using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class CartItemRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
