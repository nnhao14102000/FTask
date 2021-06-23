using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class PlanSemesterRepository : GenericRepository<PlanSemester>, IPlanSemesterRepository
    {
        private FTaskContext context;
        public PlanSemesterRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }
        public PlanSemester GetPlanSemesterByPlanSemesterId(int id)
        {
            return FindByCondition(ps => ps.PlanSemesterId == id).FirstOrDefault();
        }

        public PagedList<PlanSemester> GetPlanSemesters(PlanSemesterParameters planSemesterParameters)
        {
            var planSemesters = FindAll();
            SearchByName(ref planSemesters, planSemesterParameters.PlanSemesterName);
            return PagedList<PlanSemester>
                .ToPagedList(planSemesters, planSemesterParameters.PageNumber, planSemesterParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<PlanSemester> planSemesters, string planSemesterName)
        {
            if (!planSemesters.Any() || string.IsNullOrWhiteSpace(planSemesterName))
            {
                return;
            }
            planSemesters = planSemesters
                .Where(p => p.PlanSemesterName.ToLower()
                .Contains(planSemesterName.Trim().ToLower()));
        }
    }
}
