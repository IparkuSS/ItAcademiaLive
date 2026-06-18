using Anton.Live.Api.Interfaces.Base;
using Anton.Live.Api.Models;

namespace Anton.Live.Api.Interfaces
{
    public interface IProductRepository : IRepository
    {
        Product Add(Product product);
        Product? GetById(int id);
        List<Product> GetAll();
        void Update(Product product);
        void Delete(int id);
    }
}
