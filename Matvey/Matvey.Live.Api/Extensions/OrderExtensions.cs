namespace Matvey.Live.Api.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<DTO.Order> GetPaidOrders(this IEnumerable<DTO.Order> orders)
        {
            return orders.Where(o => o.Status == DTO.OrderStatus.Paid);
        }

        public static List<DTO.Order> GetPaidOrdersList(this IEnumerable<DTO.Order> orders)
        {
            return orders.Where(o => o.Status == DTO.OrderStatus.Paid).ToList();
        }

        public static decimal GetPaidOrdersTotalSum(this IEnumerable<DTO.Order> orders)
        {
            return orders.Where(o => o.Status == DTO.OrderStatus.Paid).Sum(o => o.TotalAmount);
        }

        public static int GetPaidOrdersCount(this IEnumerable<DTO.Order> orders)
        {
            return orders.Count(o => o.Status == DTO.OrderStatus.Paid);
        }
    }
}