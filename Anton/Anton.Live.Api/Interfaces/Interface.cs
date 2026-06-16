using Anton.Live.Api.Models;
namespace Anton.Live.Api.Interfaces
{
    public interface IReadableProducts
    {
        Product GetProductById(int id);
    }

    public interface IProductAdder
    {
        void AddProduct(Product product);
    }

    public interface IProductDeleter
    {
        bool DeleteProductById(int id);
    }
}
