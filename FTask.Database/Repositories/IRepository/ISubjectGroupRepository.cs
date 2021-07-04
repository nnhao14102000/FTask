using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Database.Repositories.IRepository
{
    public interface ISubjectGroupRepository : IGenericRepository<SubjectGroup>
    {
        PagedList<SubjectGroup> GetSubjectGroups(SubjectGroupParameters subjectGroupParameters);

        SubjectGroup GetSubjectGroupBySubjectGroupId(int id);
    }
}
