using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FTask.Database.Repositories
{
    public class PlanTopicRepository : GenericRepository<PlanTopic>, IPlanTopicRepository
    {
        private FTaskContext context;
        public PlanTopicRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }
        public PlanTopic GetPlanTopicByPlanTopicId(int id)
        {
            var planTopic = FindByCondition(x => x.PlanTopicId == id).FirstOrDefault();

            context.Entry(planTopic)
                .Reference(x => x.Topic)
                .Query()
                .Load();
                
            context.Entry(planTopic)
                .Collection(x => x.Tasks)
                .Query()
                .OrderByDescending(x => x.CreateDate)
                .Include(x => x.TaskCategory)
                .Load();

            return planTopic;
        }

        public PagedList<PlanTopic> GetPlanTopics(PlanTopicParameters planTopicParameters)
        {
            var planTopics = FindAll();

            GetByPlanSubjectId(ref planTopics, planTopicParameters.PlanSubjectId);

            GetByTopicId(ref planTopics, planTopicParameters.TopicId);

            FilterByIsComplete(ref planTopics, planTopicParameters.IsComplete);

            return PagedList<PlanTopic>
                .ToPagedList(planTopics, planTopicParameters.PageNumber, planTopicParameters.PageSize);
        }

        private void FilterByIsComplete(ref IQueryable<PlanTopic> planTopics, bool? isComplete)
        {
            if (!planTopics.Any() || isComplete is null)
            {
                return;
            }
            planTopics = planTopics
                    .Where(x => x.IsComplete == isComplete);
        }

        private void GetByTopicId(ref IQueryable<PlanTopic> planTopics, int topicId)
        {
            if (!planTopics.Any() || topicId == 0)
            {
                return;
            }
            planTopics = planTopics
                .Where(x => x.TopicId == topicId);
        }

        private void GetByPlanSubjectId(ref IQueryable<PlanTopic> planTopics, int planSubjectId)
        {
            if (!planTopics.Any() || planSubjectId == 0)
            {
                return;
            }
            planTopics = planTopics
                .Where(x => x.PlanSubjectId == planSubjectId);
        }
    }
}
