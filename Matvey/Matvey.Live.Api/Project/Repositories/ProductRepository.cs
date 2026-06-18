using Matvey.Live.Api.Project.Models;

namespace Matvey.Live.Api.Project.Repositories
    
{
    public class ProductRepository : GenericRepository<Product>
    {
        public IEnumerable<Product> GetInStock()
        {
            return _items.Where(p => p.Stock > 0);
        }

        public IEnumerable<Product> GetByPriceRange(decimal min, decimal max)
        {
            return _items.Where(p => p.Price >= min && p.Price <= max);
        }

        public IEnumerable<Product> SearchByName(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return _items;

            return _items.Where(p => p.Name.Contains(searchTerm, System.StringComparison.OrdinalIgnoreCase));
        }

        public void ReduceStock(int productId, int quantity)
        {
            var product = GetById(productId);
            if (product != null && product.Stock >= quantity)
            {
                product.Stock -= quantity;
                Console.WriteLine($"Stock reduced. Product: {product.Name}, New stock: {product.Stock}");
            }
        }
    }
}
