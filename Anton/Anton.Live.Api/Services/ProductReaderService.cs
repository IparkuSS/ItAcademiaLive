using Anton.Live.Api.Interfaces;
using Anton.Live.Api.Models;

namespace Anton.Live.Api.Services
{
    public class ProductReader : IReadableProducts
    {
        private List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Молоко", Price = 89.90 },
            new Product { Id = 2, Name = "Хлеб", Price = 45.00 },
            new Product { Id = 3, Name = "Яблоки", Price = 120.50 }
        };

        public Product GetProductById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
                
            }
            throw new Exception("Продукта нет в списке");
        }
    }
}
