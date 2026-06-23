using Anton.Live.Api.Interfaces;
using Anton.Live.Api.Models;
using Anton.Live.Api.Services.Base;

namespace Anton.Live.Api.Services
{
    public class ProductRepository : Repository, IProductRepository
    {
        private readonly List<Product> _items = new();

        public Product Add(Product product)
        {
            product.Id = NextId(_items);
            _items.Add(product);
            return product;
        }

        public Product? GetById(int id) => _items.FirstOrDefault(p => p.Id == id);

        public List<Product> GetAll() => _items;

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing is not null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item is not null) _items.Remove(item);
        }

        public new int NextId<T>(List<T> items)
        {
            throw new NotImplementedException();
        }
    }
}