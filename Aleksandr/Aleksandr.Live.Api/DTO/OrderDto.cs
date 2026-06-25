namespace Aleksandr.Live.Api.DTO
{
    [Serializable]

    public class OrderDto
    {

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public List<string> Items { get; set; }
    }
}
