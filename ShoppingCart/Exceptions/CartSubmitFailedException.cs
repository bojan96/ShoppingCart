using System;

namespace ShoppingCart.Exceptions
{
    public class CartSubmitFailedException : Exception
    {
        public CartSubmitFailedException(string message, Exception inner) 
            : base(message, inner) { }
        public CartSubmitFailedException(string message)
            : base(message) { }
    }
}
