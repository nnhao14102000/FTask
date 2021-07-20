using FTask.Api.ViewModels.PlanTopicViewModels;
using FTask.Api.ViewModels.SubjectViewModels;
using System;
using System.Collections.Generic;

namespace FTask.Api.ViewModels.PlanSubjectViewModels
{
    /// <summary>
    /// Plan subject read detail view model
    /// </summary>
    public class PlanSubjectReadDetailViewModel
    {
        /// <summary>
        /// Plan subject id
        /// </summary>
        public int PlanSubjectId { get; set; }

        /// <summary>
        /// Plan subject priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Plan subject progress
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Plan subject date created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Is plan subject complete
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Subject detail
        /// </summary>
        public SubjectReadDetailViewModel Subject { get; set; }

        /// <summary>
        /// PlanTopics in PlanSubject
        /// </summary>
        public ICollection<PlanTopicReadDetailViewModel> PlanTopics { get; set; }
    }
}
