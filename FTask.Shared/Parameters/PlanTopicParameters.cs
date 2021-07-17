using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class PlanTopicParameters : QueryStringParameters
    {        
        public int PlanSubjectId { get; set; }
        public int TopicId { get; set; }
        public bool? IsComplete { get; set; }
    }
}
