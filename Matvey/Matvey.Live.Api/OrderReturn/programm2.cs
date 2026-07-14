//using Matvey.Live.Api.OrderReturn.Models;
//using Matvey.Live.Api.OrderReturn.Services;

//namespace Matvey.Live.Api.OrderReturn
//{
//    public class programm2
//    {
//        static void Main(string[] args)
//        {
//            Console.OutputEncoding = System.Text.Encoding.UTF8;
//            Console.WriteLine("=== СИСТЕМА ВОЗВРАТА ТОВАРОВ ===\n");

//            var returnService = new ReturnService();

//            Console.WriteLine("--- Кейс 1: Успешный возврат ---");
//            var order1 = new Order(
//                1001,
//                "Иван Петров",
//                1500.50m,
//                DateTime.Now.AddDays(-5),
//                true
//            );
//            order1.DisplayOrderInfo();

//            var returnRequest1 = new ReturnRequest(order1, "Товар не подошел по размеру");
//            returnRequest1.DisplayRequestInfo();

//            returnService.ProcessReturn(returnRequest1);

//            Console.WriteLine("\n--- Кейс 2: Отказ - заказ не оплачен ---");
//            var order2 = new Order(
//                1002,
//                "Мария Смирнова",
//                2500.00m,
//                DateTime.Now.AddDays(-3),
//                false
//            );
//            order2.DisplayOrderInfo();

//            var returnRequest2 = new ReturnRequest(order2, "Передумал покупать");
//            returnRequest2.DisplayRequestInfo();

//            returnService.ProcessReturn(returnRequest2);

//            Console.WriteLine("\n--- Кейс 3: Отказ - просрочка 20 дней ---");
//            var order3 = new Order(
//                1003,
//                "Алексей Иванов",
//                3200.00m,
//                DateTime.Now.AddDays(-20),
//                true
//            );
//            order3.DisplayOrderInfo();

//            var returnRequest3 = new ReturnRequest(order3, "Обнаружен брак");
//            returnRequest3.DisplayRequestInfo();

//            returnService.ProcessReturn(returnRequest3);

//            Console.WriteLine("\n--- Кейс 4: Успешный возврат на границе 14 дней ---");
//            var order4 = new Order(
//                1004,
//                "Ольга Сидорова",
//                500.00m,
//                DateTime.Now.AddDays(-14),
//                true
//            );
//            order4.DisplayOrderInfo();

//            var returnRequest4 = new ReturnRequest(order4, "Не соответствует описанию");
//            returnRequest4.DisplayRequestInfo();

//            returnService.ProcessReturn(returnRequest4);

//            Console.WriteLine("\nНажмите любую клавишу для выхода...");
//            Console.ReadKey();
//        }
//    }
//}
