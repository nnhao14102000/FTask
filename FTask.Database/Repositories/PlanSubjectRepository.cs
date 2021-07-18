using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FTask.Database.Repositories
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
            var planSubject = FindByCondition(x => x.PlanSubjectId == id).FirstOrDefault();

            context.Entry(planSubject)
                .Collection(x => x.PlanTopics)
                .Query()
                .OrderBy(x => x.PlanTopicId)
                .Include(x => x.Topic)
                .Include(x => x.Tasks)
                    .ThenInclude(x => x.TaskCategory)
                .Load();
            
            context.Entry(planSubject)
                .Reference(x => x.Subject)
                .Query()
                .Include(x => x.Topics)
                .Load();
                
            return planSubject;
        }

        public PagedList<PlanSubject> GetPlanSubjects(PlanSubjectParameters planSubjectParameters)
        {
            var planSubjects = FindAll();

            GetByPlanSemesterId(ref planSubjects, planSubjectParameters.PlanSemesterId);

            FilterByIsComplete(ref planSubjects, planSubjectParameters.IsComplete);

            SortLatestPlan(ref planSubjects);

            return PagedList<PlanSubject>
                .ToPagedList(planSubjects, planSubjectParameters.PageNumber, planSubjectParameters.PageSize);
        }

        private void FilterByIsComplete(ref IQueryable<PlanSubject> planSubjects, bool? isComplete)
        {
            if (!planSubjects.Any() || isComplete is null)
            {
                return;
            }
            planSubjects = planSubjects
                    .Where(x => x.IsComplete == isComplete);
        }

        private void GetByPlanSemesterId(ref IQueryable<PlanSubject> planSubjects, int planSemesterId)
        {
            if (!planSubjects.Any() || planSemesterId == 0)
            {
                return;
            }
            planSubjects = planSubjects
                            .Where(ps => ps.PlanSemesterId == planSemesterId);
        }

        private void SortLatestPlan(ref IQueryable<PlanSubject> plans)
        {
            if (!plans.Any())
            {
                return;
            }            
            plans = plans
                .OrderByDescending(x => x.CreateDate);
        }
    }
}
