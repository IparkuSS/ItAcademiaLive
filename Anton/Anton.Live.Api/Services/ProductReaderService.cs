using Anton.Live.Api.Interfaces;
using Anton.Live.Api.Models;

namespace Anton.Live.Api.Services
{
    public class ProductReader : IReadableProducts, IProductAdder, IProductDeleter
    {
        private List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Молоко", Price = 89.90m },
            new Product { Id = 2, Name = "Хлеб", Price = 45.00m },
            new Product { Id = 3, Name = "Яблоки", Price = 120.50m }
        };

        public Product GetProductById(int id)
            => products.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Продукта нет в списке");

        public void AddProduct(Product product)
        {
            if (products.Any(p => p.Id == product.Id))
            {
                Console.WriteLine($"Товар с ID {product.Id} уже существует");
                return;
            }

            products.Add(product);
            Console.WriteLine($"Товар '{product.Name}' успешно добавлен");
        }

        public bool DeleteProductById(int id)
        {
            Product? productToRemove = products.FirstOrDefault(p => p.Id == id);

            if (productToRemove is not null)
            {
                products.Remove(productToRemove);
                return true;
            }

            return false;
        }
    }


}


