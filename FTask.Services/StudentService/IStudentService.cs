using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Services.StudentService
{
    public interface IStudentService
    {
        PagedList<Student> GetAllStudents(StudentParameters studentParameters);
        Student GetStudentByStudentId(string code);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
    }
}
