using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.StudentBusinessService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentService> _log;

        public StudentService(IStudentRepository studentRepository, ILogger<StudentService> log)
        {
            _studentRepository = studentRepository;
            _log = log;
        }

        public PagedList<Student> GetAllStudents(StudentParameters studentParameters)
        {
            var students = _studentRepository.GetStudents(studentParameters);
            if (students is null)
            {
                _log.LogInformation("Have no students...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {students.TotalCount} students from database...");
                return students;
            }
        }

        public Student GetStudentByStudentId(string id)
        {
            _log.LogInformation($"Search student {id}...");
            var student = _studentRepository.GetStudentByStudentId(id);
            if (student is null)
            {
                _log.LogInformation($"Can not found student {id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success student {id}...");
                return student;
            }
        }

        public void AddStudent(Student student)
        {
            _log.LogInformation($"Add student {student.StudentId} into database...");
            _studentRepository.Add(student);
            try
            {
                if (_studentRepository.SaveChanges(student))
                {
                    _log.LogInformation($"Add student {student.StudentId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Add student {student.StudentId} fail with error: {e.Message}");
            }

        }

        public void UpdateStudent(Student student)
        {
            _log.LogInformation($"Update student {student.StudentId}...");
            _studentRepository.Update(student);
            try
            {
                if (_studentRepository.SaveChanges(student))
                {
                    _log.LogInformation($"Update student {student.StudentId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update student {student.StudentId} fail with error: {e.Message}");
            }
        }

        public void RemoveStudent(Student student)
        {
            _log.LogInformation($"Remove student {student.StudentId}...");
            _studentRepository.Remove(student);
            try
            {
                if (_studentRepository.SaveChanges(student))
                {
                    _log.LogInformation($"Remove student {student.StudentId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove student {student.StudentId} fail with error: {e.Message}");
            }
        }

        public Student GetStudentByStudentEmail(string email)
        {
            _log.LogInformation($"Search student {email}...");
            var student = _studentRepository.GetStudentByStudentEmail(email);
            if (student is null)
            {
                _log.LogInformation($"Can not found student {email}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success student {email}...");
                return student;
            }
        }
    }
}
