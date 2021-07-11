using FTask.Api.ViewModels.SubjectViewModels;
using System;

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
        /// Plan semester id this plan belong to
        /// </summary>
        public int PlanSemesterId { get; set; }

        /// <summary>
        /// Subject id this plan belong to
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// Subject in Plan Subject
        /// </summary>
        public SubjectReadViewModel Subject { get; set; }
    }
}
