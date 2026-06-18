using Aleksandr.Live.Api.Domains;
using Aleksandr.Live.Api.Services.Interfaces.Base;

namespace Aleksandr.Live.Api.Services
{
    public class InMemRepository<T> : IRepository<T> where T : BaseEntity
    {
        // Статический список, чтобы данные сохранялись между запросами API
        private static readonly List<T> _entities = new List<T>();
        private static int _nextId = 1;

        public IEnumerable<T> GetAll() => _entities;

        public T GetById(int id) => _entities.FirstOrDefault(e => e.Id == id);

        public void Add(T entity)
        {
            entity.Id = _nextId++;
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                
                int index = _entities.IndexOf(existing);
                _entities[index] = entity;
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }
    }
}
