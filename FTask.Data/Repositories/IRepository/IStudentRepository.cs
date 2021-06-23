using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        PagedList<Student> GetStudents(StudentParameters studentParameters);
        Student GetStudentByStudentId(string id);
        Student GetStudentByStudentEmail(string email);
    }
}
