using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        PagedList<Subject> GetSubjects(SubjectParameters subjectParameters);

        Subject GetSubjectBySubjecId(string id);
        Subject GetSubjectInDetailBySubjecId(string id);
    }
}
