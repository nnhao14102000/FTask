using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using System.Linq;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories
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
            if (studentParameters.MajorId is null)
            {
                var allStudent = FindAll();
                SearchByName(ref allStudent, studentParameters.StudentName);

                return PagedList<Student>
                    .ToPagedList(allStudent.OrderBy(s => s.StudentName),
                        studentParameters.PageNumber,
                        studentParameters.PageSize);
            }

            var students = FindByCondition(st
                => st.MajorId.Equals(studentParameters.MajorId));

            SearchByName(ref students, studentParameters.StudentName);

            return PagedList<Student>.ToPagedList(students,
                studentParameters.PageNumber, studentParameters.PageSize);
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
            => student.StudentEmail.Equals(email)).FirstOrDefault();
        }
    }
}
