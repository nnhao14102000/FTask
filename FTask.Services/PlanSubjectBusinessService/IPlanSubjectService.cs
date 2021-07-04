using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Services.PlanSubjectBusinessService
{
    public interface IPlanSubjectService
    {
        PagedList<PlanSubject> GetAllPlanSubjects(PlanSubjectParameters planSubjectPrameters);
        PlanSubject GetPlanSubjectByPlanSubjectId(int id);
        void AddPlanSubject(PlanSubject planSubject);
        void UpdatePlanSubject(PlanSubject planSubject);
        void RemovePlanSubject(PlanSubject planSubject);
    }
}
