namespace Aleksandr.Live
{
    public class OrderService
    {
        public bool CanReturnOrder(Order order)
        {
            // Заказ оплачен
            if (!order.IsPaid)
            {
                return false;
            }

            // Срок для возврата: дата заказа + 14 дней
            DateTime returnDeadline = order.OrderDate.AddDays(14);

            // Дата не должна превышать крайний срок
            if (DateTime.UtcNow > returnDeadline)
            {
                return false;
            }

            return true; // Возврат разрешен
        }
    }
}
