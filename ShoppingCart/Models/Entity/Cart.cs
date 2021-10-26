using ShoppingCart.Models.Enums;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Models.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public CartStatus Status { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public string CreatedBy { get; set; }
    }
}
