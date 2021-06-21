using FTask.Data.Helpers;

namespace FTask.Data.Parameters
{
    public class SubjectParameters : QueryStringParameters
    {
        public string SubjectName { get; set; }
        public int SubjectGroupId { get; set; }
    }
}
