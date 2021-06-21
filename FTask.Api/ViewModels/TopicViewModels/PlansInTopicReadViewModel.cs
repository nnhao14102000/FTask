using System.Collections.Generic;

namespace FTask.Api.ViewModels.TopicViewModels
{
    /// <summary>
    /// Plan Topics in Topic read view model
    /// </summary>
    public class PlansInTopicReadViewModel
    {
        /// <summary>
        /// Plan topic id 
        /// </summary>
        public int PlanTopicId { get; set; }

        /// <summary>
        /// Plan progress
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Is plan commlete
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Plan subject id this plan belong to
        /// </summary>
        public int PlanSubjectId { get; set; }

        /// <summary>
        /// Tasks in topic
        /// </summary>
        public ICollection<TasksInTopic> Tasks { get; set; }
    }
}
