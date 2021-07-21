using System;
using FTask.Api.ViewModels.SemesterViewModels;

namespace FTask.Api.ViewModels.PlanSemesterViewModels
{
    /// <summary>
    /// Plan semester read view model
    /// </summary>
    public class PlanSemesterReadViewModel
    {
        /// <summary>
        /// Plan semester id
        /// </summary>
        public int PlanSemesterId { get; set; }

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
        /// Semester info
        /// </summary>
        /// <value></value>
        public SemesterReadViewModel Semester {get; set;}

        /// <summary>
        /// Date create plan
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Is plan completed
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
