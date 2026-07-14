namespace OrderReturnDemo.Exceptions
{
    public class ReturnValidationException : Exception
    {
        public int OrderId { get; }

        public ReturnValidationException(int orderId, string message)
            : base(message)
        {
            OrderId = orderId;
        }

        public ReturnValidationException(int orderId, string message, Exception innerException)
            : base(message, innerException)
        {
            OrderId = orderId;
        }
    }
}