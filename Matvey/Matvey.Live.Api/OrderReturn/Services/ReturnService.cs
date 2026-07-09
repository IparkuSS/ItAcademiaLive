//using Matvey.Live.Api.OrderReturn.Models;
//using Matvey.Live.Api.OrderReturn.Exceptions;

//namespace Matvey.Live.Api.OrderReturn.Services
//{
//    public class ReturnService
//    {
//        public bool CanReturnOrder(ReturnRequest request)
//        {
//            if (!request.IsOrderPaid())
//            {
//                throw new ReturnValidationException(
//                    request.Order.Id,
//                    "Возврат возможен только для оплаченных заказов"
//                );
//            }

//            if (!request.IsWithinReturnPeriod())
//            {
//                throw new ReturnValidationException(
//                    request.Order.Id,
//                    $"Возврат возможен только в течение 14 дней с момента заказа. Прошло {request.DaysSinceOrder()} дней"
//                );
//            }

//            return true;
//        }

//        public void ProcessReturn(ReturnRequest request)
//        {
//            try
//            {
//                Console.WriteLine($"\n⚙️ Обработка возврата заказа #{request.Order.Id}...");

//                if (CanReturnOrder(request))
//                {
//                    Console.WriteLine($"Возврат для заказа #{request.Order.Id} одобрен");
//                    Console.WriteLine($"Сумма к возврату: {request.Order.TotalAmount:C}");
//                    Console.WriteLine($"Причина: {request.Reason}");
//                }
//            }
//            catch (ReturnValidationException ex)
//            {
//                Console.WriteLine($" Ошибка возврата: {ex.Message}");
//            }
//        }
//    }
//}
