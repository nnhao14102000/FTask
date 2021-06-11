using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Services.StudentBusinessService
{
    public interface IStudentService
    {
        PagedList<Student> GetAllStudents(StudentParameters studentParameters);
        Student GetStudentByStudentId(string id);
        Student GetStudentByStudentEmail(string email);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
    }
}
