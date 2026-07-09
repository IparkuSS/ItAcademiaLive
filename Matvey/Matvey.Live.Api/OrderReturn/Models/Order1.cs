namespace Matvey.Live.Api.OrderReturn.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public string CustomerName { get; set; }

        public Order(int id, string customerName, decimal totalAmount, DateTime orderDate, bool isPaid)
        {
            Id = id;
            CustomerName = customerName;
            TotalAmount = totalAmount;
            OrderDate = orderDate;
            IsPaid = isPaid;
        }

        public void DisplayOrderInfo()
        {
            Console.WriteLine($"\n=== ЗАКАЗ #{Id} ===");
            Console.WriteLine($"Клиент: {CustomerName}");
            Console.WriteLine($"Дата заказа: {OrderDate:dd.MM.yyyy}");
            Console.WriteLine($"Сумма: {TotalAmount:C}");
            Console.WriteLine($"Статус оплаты: {(IsPaid ? "✅ Оплачен" : "❌ Не оплачен")}");
        }
    }
}
