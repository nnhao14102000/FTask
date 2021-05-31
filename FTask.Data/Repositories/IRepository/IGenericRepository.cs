using System.Collections.Generic;

namespace FTask.Data.Repositories.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);

        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
    }
}
