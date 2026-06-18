namespace Matvey.Live.Api.Project.Repositories
{
    public class GenericRepository<T> where T : class
    {
        protected List<T> _items = new List<T>();
        protected int _nextId = 1;

        public virtual T GetById(int id)
        {
            var property = typeof(T).GetProperty("Id");
            if (property == null)
                throw new InvalidOperationException("Entity does not have Id property");

            return _items.FirstOrDefault(item =>
            {
                var value = property.GetValue(item) as int?;
                return value == id;  
            });
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _items.ToList();  
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var property = typeof(T).GetProperty("Id");
            if (property != null)
            {
                property.SetValue(entity, _nextId++);
            }

            _items.Add(entity);
            Console.WriteLine($"[{typeof(T).Name}] Added. Total: {_items.Count}");
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null)
                throw new InvalidOperationException("Entity does not have Id property");

            var id = (int)idProperty.GetValue(entity);
            var existing = GetById(id);

            if (existing == null)
                throw new KeyNotFoundException($"Entity with Id {id} not found");

            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                if (prop.Name == "Id")
                    continue;

                var newValue = prop.GetValue(entity);
                prop.SetValue(existing, newValue);
            }

            Console.WriteLine($"[{typeof(T).Name}] Updated. Id: {id}");
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _items.Remove(entity);
                Console.WriteLine($"[{typeof(T).Name}] Deleted. Id: {id}");
            }
        }

        public virtual bool Exists(int id)
        {
            return GetById(id) != null;
        }

        public virtual int Count()
        {
            return _items.Count;
        }
    }
}
