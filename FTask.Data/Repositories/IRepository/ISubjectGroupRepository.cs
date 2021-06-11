using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ISubjectGroupRepository : IGenericRepository<SubjectGroup>
    {
        PagedList<SubjectGroup> GetSubjectGroups(SubjectGroupParameters subjectGroupParameters);

        SubjectGroup GetSubjectGroupBySubjectGroupId(int id);
    }
}
