using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class PlanSemesterParameters : QueryStringParameters
    {
        public string PlanSemesterName { get; set; }
        public string StudentId { get; set; }
        public bool? IsComplete { get; set; }
    }
}
