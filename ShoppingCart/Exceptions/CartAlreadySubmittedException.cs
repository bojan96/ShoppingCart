using System;

namespace ShoppingCart.Exceptions
{
    public class CartAlreadySubmittedException : Exception
    {
        public CartAlreadySubmittedException(string message, Exception inner) 
            : base(message, inner) { }
        public CartAlreadySubmittedException(string message)
            : base(message) { }
    }
}
