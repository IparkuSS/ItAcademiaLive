using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.Services.InterFaces;

namespace Aleksandr.Live.Api.Services
{
    public class ProductService : IProductReader
    {
        public Product GetProductById(int id)
        {

            if (id <= 0)
            {
                return null;
            }

            return new Product
            {
                Id = id,
                Name = "Базовый товар",
                Price = 150.00m,
            };
        }
    }
}
