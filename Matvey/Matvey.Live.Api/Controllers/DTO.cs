namespace Matvey.Live.Api.Serializ
{
    public class OrderDto
    {

        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
