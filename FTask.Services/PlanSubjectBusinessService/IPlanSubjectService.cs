using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

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
