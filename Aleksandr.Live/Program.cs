namespace Aleksandr.Live
{
    class Program
    {
        static void Main()
        {
            Order myOrder = new Order
            {
                OrderId = 101,
                Name = "Алексей",
                Status = OrderStatus.Processing,
                SecondName = "Алексеев",
                Email = "qwertr@mail.com"
            };

            switch (myOrder.Status)
            {
                case OrderStatus.Pending:
                    Console.WriteLine($"{myOrder.Name} {myOrder.SecondName} Заказ ожидает обработки.");
                    break;
                case OrderStatus.Processing:
                    Console.WriteLine($"{myOrder.Name} {myOrder.SecondName} Заказ собирается на складе.");
                    break;
                case OrderStatus.Shipped:
                    Console.WriteLine($"{myOrder.Name} {myOrder.SecondName} Заказ в пути.");
                    break;
                default:
                    Console.WriteLine($"{myOrder.Name} {myOrder.SecondName} Статус неизвестен.");
                    break;
            }

        }
    }
}