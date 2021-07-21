using FTask.Api.ViewModels.TopicViewModels;

namespace FTask.Api.ViewModels.PlanSubjectViewModels
{
    /// <summary>
    /// Plan topic in plan subject
    /// </summary>
    public class PlanTopicInPlanSubjectReadModel
    {
        // <summary>
        /// Plan topic id 
        // </summary>
        public int PlanTopicId { get; set; }

        /// <summary>
        /// Plan progress
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Is plan complete
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Topic
        /// </summary>
        public TopicReadViewModel Topic { get; set; }

    }
}