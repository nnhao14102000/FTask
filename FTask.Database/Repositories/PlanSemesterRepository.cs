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
                .Collection(ps => ps.PlanSubjects)
                .Query()
                .OrderBy(ps => ps.PlanSubjectId)
                .Include(planSubject => planSubject.Subject)
                .Load();

            return planSemester;
        }

        public PagedList<PlanSemester> GetPlanSemesters(PlanSemesterParameters planSemesterParameters)
        {
            var planSemesters = FindAll();
            GetByStudentId(ref planSemesters, planSemesterParameters.StudentId);
            SearchByName(ref planSemesters, planSemesterParameters.PlanSemesterName);
            return PagedList<PlanSemester>
                .ToPagedList(planSemesters, planSemesterParameters.PageNumber, planSemesterParameters.PageSize);
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
    }
}
