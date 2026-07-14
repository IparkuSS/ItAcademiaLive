using System;
using System.Collections.Generic;
using System.Text;

namespace Aleksandr.Live
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public string Sku { get; set; }              
        public DateTime UpdatedAt { get; set; }
    }
}
