using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olga.Live
{
    class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsPaid { get; private set; }

        public Order(int id, string customerName, decimal totalPrice)
        {
            Id = id;
            CustomerName = customerName;
            TotalPrice = totalPrice;

            CreatedAt = DateTime.Now;
            IsPaid = false;
        }

        public void Pay()
        {
            IsPaid = true;
        }
    }
}

