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

    }
}
