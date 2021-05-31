using System;

namespace FTask.Data.Repositories.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        /// <summary>
        /// cacs banr conf laij
        /// </summary>
        bool SaveChanges();
    }
}
