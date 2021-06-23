using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ISubjectGroupRepository : IGenericRepository<SubjectGroup>
    {
        PagedList<SubjectGroup> GetSubjectGroups(SubjectGroupParameters subjectGroupParameters);

        SubjectGroup GetSubjectGroupBySubjectGroupId(int id);
    }
}
