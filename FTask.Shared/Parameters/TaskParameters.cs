using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class TaskParameters : QueryStringParameters
    {
        public enum Types {
            LastestTime, HighestPriority
        }
        public string TaskSearchValue { get; set; }
        public int PlanTopicId { get; set; }
        public Types? SortOptions { get; set; }
        public bool? IsComplete { get; set; }
    }
}
