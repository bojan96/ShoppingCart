using System;

namespace ShoppingCart.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message)
            : base(message) { }

        public EntityNotFoundException(int entityId)
            : this($"Entity with id {entityId} not found") { }
    }
}
