using FTask.Shared.Helpers;

namespace FTask.Shared.Parameters
{
    public class StudentParameters : QueryStringParameters
    {
        public string MajorId { get; set; }
        public string StudentName { get; set; }
    }
}
