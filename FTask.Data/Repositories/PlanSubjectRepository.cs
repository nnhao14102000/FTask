using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class PlanSubjectRepository : GenericRepository<PlanSubject>, IPlanSubjectRepository
    {
        private FTaskContext context;
        public PlanSubjectRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }
        public PlanSubject GetPlanSubjectByPlanSubjectId(int id)
        {
            return FindByCondition(x => x.PlanSubjectId == id).FirstOrDefault();
        }

        public PagedList<PlanSubject> GetPlanSubjects(PlanSubjectParameters planSubjectParameters)
        {
            return PagedList<PlanSubject>
                .ToPagedList(FindAll(), planSubjectParameters.PageNumber, planSubjectParameters.PageSize);
        }
    }
}
