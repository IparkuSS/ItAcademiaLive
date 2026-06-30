namespace Aleksandr.Live
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

    }
}
