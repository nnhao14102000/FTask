using System.Security.Cryptography.X509Certificates;
using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FTask.Database.Repositories
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
            var planSemester = FindByCondition(ps => ps.PlanSemesterId == id)
                                    .FirstOrDefault();

            context.Entry(planSemester)
                .Reference(x => x.Semester)
                .Query()
                .Load();

            context.Entry(planSemester)
                .Collection(ps => ps.PlanSubjects)
                .Query()
                .OrderByDescending(ps => ps.CreateDate)
                .Include(planSubject => planSubject.Subject)
                .Include(planSubject => planSubject.PlanTopics)
                    .ThenInclude(topic => topic.Topic)
                .Load();

            context.Entry(planSemester)
                .Collection(ps => ps.PlanSubjects)
                .Query()
                .OrderByDescending(ps => ps.CreateDate)
                .Include(planSubject => planSubject.Subject)
                .Include(planSubject => planSubject.PlanTopics)
                    .ThenInclude(planTopic => planTopic.Tasks)
                        .ThenInclude(taskCategory => taskCategory.TaskCategory)
                .Load();

            return planSemester;
        }

        public PagedList<PlanSemester> GetPlanSemesters(PlanSemesterParameters planSemesterParameters)
        {
            var planSemesters = FindAll();

            GetByStudentId(ref planSemesters, planSemesterParameters.StudentId);

            SearchByName(ref planSemesters, planSemesterParameters.PlanSemesterName);

            FilterByIsComplete(ref planSemesters, planSemesterParameters.IsComplete);

            SortLatestPlan(ref planSemesters);

            foreach (var item in planSemesters)
            {
                context.Entry(item)
                    .Reference(x => x.Semester)
                    .Query()
                    .Load();
            }

            return PagedList<PlanSemester>
                .ToPagedList(planSemesters, planSemesterParameters.PageNumber, planSemesterParameters.PageSize);
        }

        private void FilterByIsComplete(ref IQueryable<PlanSemester> planSemesters, bool? isComplete)
        {
            if (!planSemesters.Any() || isComplete is null)
            {
                return;
            }
            planSemesters = planSemesters
                    .Where(x => x.IsComplete == isComplete);
        }

        private void GetByStudentId(ref IQueryable<PlanSemester> planSemesters, string studentId)
        {
            if (!planSemesters.Any() || string.IsNullOrWhiteSpace(studentId))
            {
                return;
            }
            planSemesters = planSemesters
                .Where(p => p.StudentId.ToLower()
                .Contains(studentId.Trim().ToLower()));
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

        private void SortLatestPlan(ref IQueryable<PlanSemester> plans)
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
