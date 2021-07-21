using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Database.Repositories.IRepository
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        PagedList<Subject> GetSubjects(SubjectParameters subjectParameters);

        Subject GetSubjectBySubjectId(string id);
        Subject GetSubjectInDetailBySubjectId(string id);
    }
}
