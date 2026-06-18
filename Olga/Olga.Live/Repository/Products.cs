using System;
using System.Collections.Generic;
using System.Text;

namespace Olga.Live.Repository
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductRepository : IRepository<Product>
    {
        public Product GetById(int id)
        {
            return new Product { Id = id, Name = "Product" };
        }
        public void Add(Product item) { }
        public void Update(Product item) { }
        public void Delete(int id) { }
    }
}
