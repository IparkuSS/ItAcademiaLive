using Anton.Live.Api.Enums;
using Anton.Live.Api.Interfaces.Base;
using Anton.Live.Api.Models;

namespace Anton.Live.Api.Interfaces
{
    public interface IOrderRepository : IRepository
    {
        Order Add(Order order);
        Order? GetById(int id);
        List<Order> GetAll();
        void Update(Order order);
        void Delete(int id);
    }
}
