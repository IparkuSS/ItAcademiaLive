using Anton.Live.Api.Interfaces;
using Anton.Live.Api.Models;
using Anton.Live.Api.Services.Base;

namespace Anton.Live.Api.Services
{
    public class OrderRepository : Repository, IOrderRepository
    {
        private readonly List<Order> _items = new();

        public Order Add(Order order)
        {
            order.Id = NextId(_items);
            _items.Add(order);
            return order;
        }

        public Order? GetById(int id) => _items.FirstOrDefault(o => o.Id == id);

        public List<Order> GetAll() => _items;

        public void Update(Order order)
        {
            var existing = GetById(order.Id);
            if (existing is not null)
            {
                existing.CustomerName = order.CustomerName;
                existing.TotalAmount = order.TotalAmount;
                existing.Status = order.Status;
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is not null) _items.Remove(item);
        }

        public new int NextId<T>(List<T> items)
        {
            throw new NotImplementedException();
        }
    }
}