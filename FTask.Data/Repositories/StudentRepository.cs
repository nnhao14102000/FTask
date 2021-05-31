using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly FTaskContext _context;
        public StudentRepository(FTaskContext context) : base (context)
        {
            _context = context;
        }

        public Student GetStudentByStudentId(string id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id.ToUpper() == id.ToUpper());
            return student;
        }
    }
}
