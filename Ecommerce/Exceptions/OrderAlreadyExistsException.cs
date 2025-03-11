namespace Ecommerce.Exceptions
{
    public class OrderAlreadyExistsException : Exception
    {
        public OrderAlreadyExistsException() { }
        public OrderAlreadyExistsException(string msg) : base(msg)
        { }
    }
}
