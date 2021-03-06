using System;

namespace ShoppingCart.Models
{
    public class CartItemDetails
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreated { get; set; }
        // Null value means it was never updated
        public DateTime? TimeUpdated { get; set; }
        public string CreatedBy { get; set; }
    }
}
