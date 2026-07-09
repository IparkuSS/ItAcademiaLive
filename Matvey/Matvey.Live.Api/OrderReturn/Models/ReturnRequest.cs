namespace Matvey.Live.Api.OrderReturn.Models
{
    public class ReturnRequest
    {
        public Order Order { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Reason { get; set; }

        public ReturnRequest(Order order, string reason)
        {
            Order = order;
            ReturnDate = DateTime.Now;
            Reason = reason;
        }

        public int DaysSinceOrder()
        {
            return (ReturnDate - Order.OrderDate).Days;
        }

        public bool IsWithinReturnPeriod()
        {
            return DaysSinceOrder() <= 14;
        }

        public bool IsOrderPaid()
        {
            return Order.IsPaid;
        }

        public void DisplayRequestInfo()
        {
            Console.WriteLine($"\n=== ЗАЯВКА НА ВОЗВРАТ ===");
            Console.WriteLine($"Заказ #{Order.Id}");
            Console.WriteLine($"Дата возврата: {ReturnDate:dd.MM.yyyy}");
            Console.WriteLine($"Дней с момента заказа: {DaysSinceOrder()}");
            Console.WriteLine($"Причина: {Reason}");
            Console.WriteLine($"Статус оплаты: {(Order.IsPaid ? "Оплачен" : "Не оплачен")}");
        }
    }
}