using System.Collections.Generic;
using System.Collections.Generic;
using Matvey.Live.Api.Models;

namespace Matvey.Live.Api.Interfaces
{
    public interface IProductReader
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        bool ProductExists(int id);
    }
}