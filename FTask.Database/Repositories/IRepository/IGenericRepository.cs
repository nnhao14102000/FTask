using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FTask.Database.Repositories.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        bool SaveChanges();
    }
}
