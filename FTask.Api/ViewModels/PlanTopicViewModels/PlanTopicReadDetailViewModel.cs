namespace FTask.Api.ViewModels.PlanTopicViewModels
{
    public class PlanTopicReadDetailViewModel
    {
        public int PlanTopicId { get; set; }
        public int Progress { get; set; }
        public bool IsComplete { get; set; }
        public int TopicId { get; set; }
        public int PlanSubjectId { get; set; }
    }
}
