using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        PagedList<Student> GetStudents(StudentParameters studentParameters);
        Student GetStudentByStudentId(string id);
    }
}
