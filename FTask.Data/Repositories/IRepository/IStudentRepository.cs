using FTask.Data.Models;

namespace FTask.Data.Repositories.IRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student GetStudentByStudentId(string id);
    }
}
