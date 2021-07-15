using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class TaskParameters : QueryStringParameters
    {
        public string TaskSearchValue { get; set; }
        public int PlanTopicId { get; set; }
    }
}
