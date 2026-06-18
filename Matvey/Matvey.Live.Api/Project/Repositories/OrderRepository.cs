using Matvey.Live.Api.Project.Models;

namespace Matvey.Live.Api.Project.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public IEnumerable<Order> GetByCustomer(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
                return Enumerable.Empty<Order>();

            return _items.Where(o => o.SecondName.Contains(customerName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Order> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Enumerable.Empty<Order>();

            return _items.Where(o => o.Email.Contains(email, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Order> GetByDateRange(DateTime from, DateTime to)
        {
            return _items.Where(o => o.OrderDate >= from && o.OrderDate <= to);
        }

        public decimal GetTotalRevenue()
        {
            return _items.Sum(o => o.TotalAmount);
        }

        public IEnumerable<Order> GetOrdersAbove(decimal amount)
        {
            return _items.Where(o => o.TotalAmount >= amount);
        }
    }
}