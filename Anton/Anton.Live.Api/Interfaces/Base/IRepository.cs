using Anton.Live.Api.Models;

namespace Anton.Live.Api.Interfaces.Base
{
    public interface IRepository
    {
        protected int NextId<T>(List<T> items);
    }
}
