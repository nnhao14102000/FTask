using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(FTaskContext context) : base (context)
        {
        }

        public IEnumerable<Student> GetStudents()
        {
            return FindAll().OrderBy(st => st.Name);
        }

        public Student GetStudentByStudentId(string id)
        {
            return FindByCondition(student => student.Id.Equals(id)).FirstOrDefault();
        }
                
    }
}
