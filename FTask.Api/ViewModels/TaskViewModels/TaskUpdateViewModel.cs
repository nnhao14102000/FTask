using System;
using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.TaskViewModels
{
    /// <summary>
    /// Task Update view model
    /// </summary>
    public class TaskUpdateViewModel
    {
        /// <summary>
        /// Task Description
        /// </summary>
        [Required]
        [StringLength(200)]
        public string TaskDescription { get; set; }

        /// <summary>
        /// Estimate complete time
        /// </summary>
        public int EstimateTime { get; set; } = 0;

        /// <summary>
        /// EffortTime complete time
        /// </summary>
        public int EffortTime { get; set; } = 0;

        /// <summary>
        /// Deadline
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Priority of task
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = ("Can only bettween 0...Max int"))]
        public int Priority { get; set; } = 0;

        /// <summary>
        /// Is task complete
        /// </summary>
        [Required]
        public bool IsComplete { get; set; } = false;
    }
}
