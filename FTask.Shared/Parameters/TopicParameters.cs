using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class TopicParameters : QueryStringParameters
    {
        public string TopicName { get; set; }
        public string SubjectId {get; set;}
    }
}
