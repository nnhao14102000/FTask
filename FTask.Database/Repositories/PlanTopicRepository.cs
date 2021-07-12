using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
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
            return FindByCondition(x => x.PlanTopicId == id).FirstOrDefault();
        }

        public PagedList<PlanTopic> GetPlanTopics(PlanTopicParameters planTopicParameters)
        {
            var planTopics = FindAll();            
            GetByPlanSubjectId(ref planTopics, planTopicParameters.PlanSubjectId);
            GetByTopicId(ref planTopics, planTopicParameters.TopicId);

            return PagedList<PlanTopic>
                .ToPagedList(planTopics, planTopicParameters.PageNumber, planTopicParameters.PageSize);
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
