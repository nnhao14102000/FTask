using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Services.PlanTopicBusinessService
{
    public interface IPlanTopicService
    {
        PagedList<PlanTopic> GetAllPlanTopics(PlanTopicParameters planTopicPrameters);
        PlanTopic GetPlanTopicByPlanTopicId(int id);
        void AddPlanTopic(PlanTopic PlanTopic);
        void UpdatePlanTopic(PlanTopic PlanTopic);
        void RemovePlanTopic(PlanTopic PlanTopic);
    }
}
