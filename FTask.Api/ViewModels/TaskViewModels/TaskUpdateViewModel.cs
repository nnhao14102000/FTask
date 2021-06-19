using System;
using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.TaskViewModels
{
    public class TaskUpdateViewModel
    {
        /// <summary>
        /// Estimate complete time
        /// </summary>
        public int EstimateTime { get; set; } = 0;

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
