using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Services.SubjectBusinessService
{
    public interface ISubjectService
    {
        PagedList<Subject> GetAllSubjects(SubjectParameters subjectPrameters);
        Subject GetSubjectBySubjectId(string Id);
        void AddSubject(Subject subject);
        void UpdateSubject(Subject subject);
        void RemoveSubject(Subject subject);
    }
}
