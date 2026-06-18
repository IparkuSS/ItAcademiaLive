using Aleksandr.Live.Api.Domains;

namespace Aleksandr.Live.Api.Services.Interfaces.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
