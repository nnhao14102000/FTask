using FTask.Data.Models;
using System.Collections.Generic;

namespace FTask.Services.StudentService
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentByStudentId(string code);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
    }
}
