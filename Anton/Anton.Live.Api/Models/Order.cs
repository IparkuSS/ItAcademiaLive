using Anton.Live.Api.Enums;

namespace Anton.Live.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatusEnum Status { get; set; }
    }
}