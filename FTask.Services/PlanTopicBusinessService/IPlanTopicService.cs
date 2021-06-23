using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Services.PlanTopicBusinessService
{
    public interface IPlanTopicService
    {
        PagedList<PlanTopic> GetAllPlanTopics(PlanTopicParameters planTopicPrameters);
        PlanTopic GetPlanTopicByPlanTopicId(int id);
        void AddPlanTopic(PlanTopic planTopic);
        void UpdatePlanTopic(PlanTopic planTopic);
        void RemovePlanTopic(PlanTopic planTopic);
    }
}
