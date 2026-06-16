using Aleksandr.Live.Api.Domains;

namespace Aleksandr.Live.Api.Services.InterFaces
{
    
    public interface IProductReader
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProductById(int id);
    }
}
