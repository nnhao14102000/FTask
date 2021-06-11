using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
namespace FTask.Services.SubjectGroupBusinessService
{
    public interface ISubjectGroupService
    {
        PagedList<SubjectGroup> GetAllSubjectGroups(SubjectGroupParametes subjectGroupPrameters);
        SubjectGroup GetSubjectGroupBySubjectGroupId(int Id);
        void AddSubjectGroup(SubjectGroup subjectGroup);
        void UpdateSubjectGroup(SubjectGroup subjectGroup);
        void RemoveSubjectGroup(SubjectGroup subjectGroup);
    }
}
