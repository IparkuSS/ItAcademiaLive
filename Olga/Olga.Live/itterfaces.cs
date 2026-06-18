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
        public interface IProductAdder
        {
            void Add(Product product);
        }
        public interface IProductRemover
        {
            void Remove(int id);
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class ProductManager : IProductReader, IProductAdder, IProductRemover
        {
            public Product GetById(int id)
            {
                return new Product { Id = id, Name = "Product" };
            }

            public void Add(Product product)
            {
                Console.WriteLine("Product added");
            }

            public void Remove(int id)
            {
                Console.WriteLine("Product removed");
            }
        }
    }
}
