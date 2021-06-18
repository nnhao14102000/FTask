using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface IPlanSubjectRepository : IGenericRepository<PlanSubject>
    {
        PagedList<PlanSubject> GetPlanSubjects(PlanSubjectParameters planSubjectParameter);
        PlanSubject GetPlanSubjectByPlanSubjectId(int id);
    }
}
