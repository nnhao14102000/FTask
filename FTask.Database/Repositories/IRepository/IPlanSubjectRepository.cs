using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Database.Repositories.IRepository
{
    public interface IPlanSubjectRepository : IGenericRepository<PlanSubject>
    {
        PagedList<PlanSubject> GetPlanSubjects(PlanSubjectParameters planSubjectParameter);
        PlanSubject GetPlanSubjectByPlanSubjectId(int id);
    }
}
