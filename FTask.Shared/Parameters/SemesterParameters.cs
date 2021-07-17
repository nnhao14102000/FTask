using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class SemesterParameters : QueryStringParameters
    {
        public string SemesterName { get; set; }
        public bool? IsComplete { get; set; }
    }
}
