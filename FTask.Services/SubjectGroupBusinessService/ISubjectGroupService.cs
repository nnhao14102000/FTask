using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Services.SubjectGroupBusinessService
{
    public interface ISubjectGroupService
    {
        PagedList<SubjectGroup> GetAllSubjectGroups(SubjectGroupParameters subjectGroupPrameters);
        SubjectGroup GetSubjectGroupBySubjectGroupId(int Id);
        void AddSubjectGroup(SubjectGroup subjectGroup);
        void UpdateSubjectGroup(SubjectGroup subjectGroup);
        void RemoveSubjectGroup(SubjectGroup subjectGroup);
    }
}
