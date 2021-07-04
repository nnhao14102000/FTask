using System;
using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.SemesterViewModels
{
    /// <summary>
    /// Semester add view model
    /// </summary>
    public class SemesterAddViewModel
    {
        /// <summary>
        /// Semester Id, not null, max length =10
        /// </summary>
        [Required]
        [StringLength(10)]
        public string SemesterId { get; set; }

        /// <summary>
        /// Semester Name, not null, max length = 50
        /// </summary>
        [Required]
        [StringLength(50)]
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
        /// Is Semester complete, not null
        /// </summary>
        [Required]
        public bool IsComplete { get; set; }
    }
}
