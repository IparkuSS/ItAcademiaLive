using Aleksandr.Live.Api.Domains;

namespace Aleksandr.Live.Api.Services.InterFaces
{

    public interface IProductReader
    {
        Product GetProductById(int id);
    }
}
