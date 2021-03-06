using System;

namespace FTask.Api.ViewModels.SemesterViewModels
{
    /// <summary>
    /// Semester Read view model
    /// </summary>
    public class SemesterReadViewModel
    {
        /// <summary>
        /// Semester Id
        /// </summary>
        public string SemesterId { get; set; }

        /// <summary>
        /// Semester Name
        /// </summary>
        public string SemesterName { get; set; }

        /// <summary>
        /// The begin day of semester
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The end day of semester
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Is Semester complete
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
