using System;
using System.Collections.Generic;
using System.Text;

namespace Olga.Live
{
    internal class itterfaces
    {
        public interface IProductReader
        {
            Product GetById(int id);
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class ProductReader : IProductReader
        {
            public Product GetById(int id)
            {
                return new Product { Id = id, Name = "Product" };
            }
        }
    }
}
