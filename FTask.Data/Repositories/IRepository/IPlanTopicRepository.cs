using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface IPlanTopicRepository : IGenericRepository<PlanTopic>
    {
        PagedList<PlanTopic> GetPlanTopics(PlanTopicParameters planTopicParameter);
        PlanTopic GetPlanTopicByPlanTopicId(int id);
    }
}
