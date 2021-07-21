using System;
using System.Collections.Generic;
using FTask.Api.ViewModels.SemesterViewModels;

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
        /// Semester info
        /// </summary>
        /// <value></value>
        public SemesterReadDetailViewModel Semester { get; set; }

        /// <summary>
        /// Date plan created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Is plan completed
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// List of Plan Subject of Plan Semester
        /// </summary>
        public ICollection<PlanSubjectInPlanSemesterReadViewModel> PlanSubjects { get; set; }
    }
}
