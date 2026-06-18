using System;
using System.Collections.Generic;
using System.Text;

namespace Olga.Live.Repository
{
    public class Order2

    {
        public int Id { get; set; }
        public string Number { get; set; }
    }

    public class OrdersRepository : IRepository<Order2>
    {
        public Order2 GetById(int id)
        {
            return new Order2 { Id = id, Number = "001" };
        }
        public void Add(Order2 item) { }
        public void Update(Order2 item) { }
        public void Delete(int id) { }
    }
}
