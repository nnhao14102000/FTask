using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class TaskParameters : QueryStringParameters
    {
        public string TaskSearchValue { get; set; }
        public int PlanTopicId { get; set; }
        public bool SortWithHighPriority { get; set; }
        public bool? IsComplete { get; set; }
    }
}
