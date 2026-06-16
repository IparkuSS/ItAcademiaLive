using Matvey.Live.Api.Models;

namespace Matvey.Live.Api.Interfaces
{
    public interface IProductRemover
    {
        bool RemoveProduct(int id);
        int RemoveProductsByCategory(string category);
        void ClearAllProducts();
    }
}