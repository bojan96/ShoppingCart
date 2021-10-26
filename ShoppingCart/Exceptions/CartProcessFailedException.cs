using System;

namespace ShoppingCart.Exceptions
{
    public class CartProcessFailedException : Exception
    {
        public CartProcessFailedException(string message) : base(message) { }
    }
}
