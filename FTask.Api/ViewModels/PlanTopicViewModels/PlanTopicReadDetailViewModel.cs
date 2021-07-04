﻿namespace FTask.Api.ViewModels.PlanTopicViewModels
{
    /// <summary>
    /// Plan topic read detail view model
    /// </summary>
    public class PlanTopicReadDetailViewModel
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
        /// Topic id this plan belong to
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Plan subject id this plan belong to
        /// </summary>
        public int PlanSubjectId { get; set; }
    }
}
