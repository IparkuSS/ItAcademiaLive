using System.Collections.Generic;
using Matvey.Live.Api.Models;

namespace Matvey.Live.Api.Interfaces
{
    public interface IProductAdder
    {
        void AddProduct(Product product);
        void AddProducts(IEnumerable<Product> products);
        int GetNextId();
    }
}