using System;
using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.PlanSemesterViewModels
{
    /// <summary>
    /// Plan semester add view model
    /// </summary>
    public class PlanSemesterAddViewModel
    {
        /// <summary>
        /// Plan semester name, allow null, max length = 50
        /// </summary>
        [StringLength(50)]
        public string PlanSemesterName { get; set; } = "Unknown Plan Semester";

        /// <summary>
        /// Student id of student in this semester, not null, max length = 20
        /// </summary>
        [Required]
        [StringLength(20)]
        public string StudentId { get; set; }

        /// <summary>
        /// Semester id of semester that this plan belong to, not null, max length = 10
        /// </summary>
        [Required]
        [StringLength(10)]
        public string SemesterId { get; set; }

        /// <summary>
        /// Date create semester plan
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Is complete plan in semester, not null 
        /// </summary>
        [Required]
        public bool IsComplete { get; set; } = false;
    }
}
