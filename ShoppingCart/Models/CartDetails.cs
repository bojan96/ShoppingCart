using ShoppingCart.Models.Enums;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class CartDetails
    {
        public int Id { get; set; }
        public CartStatus Status { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public string CreatedBy { get; set; }
        public List<CartItemShortDetails> CartItems { get; set; }
    }
}
