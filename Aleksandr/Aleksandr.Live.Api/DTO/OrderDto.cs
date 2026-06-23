namespace Aleksandr.Live.Api.DTO
{
    public class OrderDto
    {

        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public List<string> Items { get; set; }
    }
}
