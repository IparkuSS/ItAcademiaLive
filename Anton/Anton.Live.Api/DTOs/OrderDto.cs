namespace Anton.Live.Api.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
    }
}
