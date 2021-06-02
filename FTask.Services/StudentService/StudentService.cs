using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FTask.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StudentService> _log;

        public StudentService(IUnitOfWork unitOfWork, ILogger<StudentService> log)
        {
            _unitOfWork = unitOfWork;
            _log = log;
        }        

        public PagedList<Student> GetAllStudents(StudentParameters studentParameters)
        {            
            var students = _unitOfWork.Students.GetStudents(studentParameters);
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
            var student = _unitOfWork.Students.GetStudentByStudentId(id);
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
            _log.LogInformation($"Add student {student.Id} into database...");
            _unitOfWork.Students.Add(student);
            try
            {
                if (_unitOfWork.SaveChanges())
                {
                    _log.LogInformation($"Add student {student.Id} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Add student {student.Id} fail with error: {e.Message}");
            }

        }

        public void UpdateStudent(Student student)
        {
            _log.LogInformation($"Update student {student.Id}...");
            _unitOfWork.Students.Update(student);
            try
            {
                if (_unitOfWork.SaveChanges())
                {
                    _log.LogInformation($"Update student {student.Id} success...");
                }
            }
            catch(Exception e)
            {
                _log.LogError($"Update student {student.Id} fail with error: {e.Message}");
            }            
        }

        public void RemoveStudent(Student student)
        {
            _log.LogInformation($"Remove student {student.Id}...");
            _unitOfWork.Students.Remove(student);
            try
            {
                if (_unitOfWork.SaveChanges())
                {
                    _log.LogInformation($"Remove student {student.Id} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove student {student.Id} fail with error: {e.Message}");
            }
        }        
    }
}
