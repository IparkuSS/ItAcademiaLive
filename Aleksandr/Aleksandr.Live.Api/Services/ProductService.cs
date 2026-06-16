using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.Services.InterFaces;

namespace Aleksandr.Live.Api.Services
{
    public class ProductService : IProductReader, IProductCreator, IProductDeleter
    {

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Товар не может быть null");
            }

            Console.WriteLine($"Товар '{product.Name}' успешно добавлен.");
        }

        public void DeleteProduct(int id)
        {

            Console.WriteLine($"Товар с ID {id} успешно удален.");
            
        }

        public Product GetProductById(int id)
        {
                        
            return new Product
            {
                Id = id,
                Name = "Товар",
                Price = 150.00m,
            };
        }
    }
}
