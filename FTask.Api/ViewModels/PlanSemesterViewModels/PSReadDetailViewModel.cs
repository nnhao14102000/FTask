using System;

namespace FTask.Api.ViewModels.PlanSemesterViewModels
{
    /// <summary>
    /// Plan semester read detail view models
    /// </summary>
    public class PSReadDetailViewModel
    {
        /// <summary>
        /// Plan semester id
        /// </summary>
        public int PlanSemesterid { get; set; }

        /// <summary>
        /// Plan semester name
        /// </summary>
        public string PlanSemesterName { get; set; }

        /// <summary>
        /// Student id of student in this semester
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// Semester id of semester that this plan belong to
        /// </summary>
        public string SemesterId { get; set; }

        /// <summary>
        /// Date plan created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Is plan completed
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
