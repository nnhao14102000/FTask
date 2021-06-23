using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface IPlanTopicRepository : IGenericRepository<PlanTopic>
    {
        PagedList<PlanTopic> GetPlanTopics(PlanTopicParameters planTopicParameter);
        PlanTopic GetPlanTopicByPlanTopicId(int id);
    }
}
