using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        PagedList<Subject> GetSubjects(SubjectParameters subjectParameters);

        Subject GetSubjectBySubjecId(string id);
    }
}
