using FTask.Api.ViewModels.PlanTopicViewModels;
using FTask.Api.ViewModels.SubjectViewModels;
using System;
using System.Collections.Generic;

namespace FTask.Api.ViewModels.PlanSemesterViewModels
{
    /// <summary>
    /// Plan Subjects in Plan Semester view model
    /// </summary>
    public class PlanSubjectInPlanSemesterReadViewModel
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
        /// Date plan is created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Is plan complete
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Subject in Plan Subject
        /// </summary>
        public SubjectReadViewModel Subject { get; set; }
    }
}
