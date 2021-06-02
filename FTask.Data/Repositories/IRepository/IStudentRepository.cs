using FTask.Data.Models;
using System.Collections.Generic;

namespace FTask.Data.Repositories.IRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByStudentId(string id);
    }
}
