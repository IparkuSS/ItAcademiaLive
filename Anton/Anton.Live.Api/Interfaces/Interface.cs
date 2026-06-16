using Anton.Live.Api.Models;
namespace Anton.Live.Api.Interfaces
{
    public interface IReadableProducts
    {
        Product GetProductById(int id);
    }
}
