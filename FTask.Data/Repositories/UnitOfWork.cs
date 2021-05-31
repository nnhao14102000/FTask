using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;

namespace FTask.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FTaskContext context;

        public UnitOfWork(FTaskContext context)
        {
            this.context = context;
            Students = new StudentRepository(context);
            //conf laij nhung repo khac 
        }
        public IStudentRepository Students { get; }

        public void Dispose()
        {
            context.Dispose();// close connection
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
