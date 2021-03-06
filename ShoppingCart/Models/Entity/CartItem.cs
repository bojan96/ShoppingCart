using System;

namespace ShoppingCart.Models.Entity
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreated { get; set; }
        // Null value means it was never updated
        public DateTime? TimeUpdated { get; set; }
        public string CreatedBy { get; set; }
    }
}
