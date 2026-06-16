using Aleksandr.Live.Api.Domains;

namespace Aleksandr.Live.Api.Services.InterFaces
{
    /// <summary>
    /// Получение товара по id
    /// </summary>
    public interface IProductReader
    {
        Product GetProductById(int id);
    }
}
