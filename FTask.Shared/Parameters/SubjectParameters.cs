using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class SubjectParameters : QueryStringParameters
    {
        public string SubjectName { get; set; }

        public string SubjectId { get; set; }
        public int SubjectGroupId { get; set; }
    }
}
