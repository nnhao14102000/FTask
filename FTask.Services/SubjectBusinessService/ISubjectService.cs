using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Services.SubjectBusinessService
{
    public interface ISubjectService
    {
        PagedList<Subject> GetAllSubjects(SubjectParameters subjectPrameters);
        Subject GetSubjectBySubjectId(string Id);
        Subject GetSubjectInDetailBySubjectId(string Id);
        void AddSubject(Subject subject);
        void UpdateSubject(Subject subject);
        void RemoveSubject(Subject subject);
    }
}
