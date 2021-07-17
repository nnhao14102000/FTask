using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using System;
using System.Linq;

namespace FTask.Database.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private FTaskContext context { get; set; }
        public StudentRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }

        public PagedList<Student> GetStudents(StudentParameters studentParameters)
        {
            var students = FindAll();

            FilterByMajorId(ref students, studentParameters.MajorId);

            SearchByName(ref students, studentParameters.StudentName);

            SearchByStudentId(ref students, studentParameters.StudentId);

            return PagedList<Student>.ToPagedList(students.OrderBy(s => s.StudentId),
                studentParameters.PageNumber, studentParameters.PageSize);
        }

        private void SearchByStudentId(ref IQueryable<Student> students, string studentId)
        {
            if (!students.Any() || string.IsNullOrWhiteSpace(studentId))
            {
                return;
            }
            students = students
                .Where(st => st.StudentId.ToLower()
                .Contains(studentId.Trim().ToLower()));
        }

        private void FilterByMajorId(ref IQueryable<Student> students, string majorId)
        {
            if (!students.Any() || string.IsNullOrWhiteSpace(majorId))
            {
                return;
            }
            students = students
                .Where(s => s.MajorId == majorId);
        }

        private void SearchByName(ref IQueryable<Student> students, string name)
        {
            if (!students.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            students = students
                .Where(st => st.StudentName.ToLower()
                .Contains(name.Trim().ToLower()));
        }

        public Student GetStudentByStudentId(string id)
        {
            return FindByCondition(student
                => student.StudentId.Equals(id)).FirstOrDefault();
        }

        public Student GetStudentByStudentEmail(string email)
        {
            return FindByCondition(student
            => student.StudentEmail.ToLower().Equals(email.ToLower())).FirstOrDefault();
        }
    }
}
