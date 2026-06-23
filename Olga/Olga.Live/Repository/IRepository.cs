using System;
using System.Collections.Generic;
using System.Text;

namespace Olga.Live.Repository
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
