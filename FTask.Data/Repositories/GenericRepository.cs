using FTask.Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbSet<T> DbSet;

        private readonly DbContext DbContext ;

        public GenericRepository(DbContext DbContext)
        {
            this.DbContext = DbContext;
            DbSet = DbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Add(T obj)
        {
            DbSet.Add(obj);
        }

        public void Update(T obj)
        {
            DbSet.Attach(obj);
            DbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(T obj)
        {
            DbSet.Remove(obj);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
