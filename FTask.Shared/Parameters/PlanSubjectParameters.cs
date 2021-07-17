using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class PlanSubjectParameters : QueryStringParameters
    {
        public int PlanSemesterId { get; set; }
        public bool? IsComplete { get; set; }
    }
}
