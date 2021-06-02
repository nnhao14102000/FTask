using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(FTaskContext context) : base (context)
        {
        }

        public PagedList<Student> GetStudents(StudentParameters studentParameters)
        {
            if(studentParameters.MajorId is null)
            {
                return PagedList<Student>.ToPagedList(FindAll().OrderBy(st => st.Name),
                studentParameters.PageNumber, studentParameters.PageSize);
            }

            var students = FindByCondition(st => st.MajorId.Equals(studentParameters.MajorId))
                    .OrderBy(st => st.Name);
            return PagedList<Student>.ToPagedList(students,
                studentParameters.PageNumber, studentParameters.PageSize);

        }

        public Student GetStudentByStudentId(string id)
        {
            return FindByCondition(student => student.Id.Equals(id)).FirstOrDefault();
        }
                
    }
}
