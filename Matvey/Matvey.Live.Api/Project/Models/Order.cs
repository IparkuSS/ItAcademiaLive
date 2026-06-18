namespace Matvey.Live.Api.Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
    }
}
