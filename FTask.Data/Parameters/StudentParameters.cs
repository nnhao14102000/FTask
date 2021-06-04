using FTask.Data.Helpers;

namespace FTask.Data.Parameters
{
    public class StudentParameters: QueryStringParameters
    {
        public string MajorId { get; set; }
        public string StudentName { get; set; }
    }
}
