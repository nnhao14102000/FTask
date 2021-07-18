using System;
using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.TaskViewModels
{
    /// <summary>
    /// Task add view model
    /// </summary>
    public class TaskAddViewModel
    {
        /// <summary>
        /// Task description
        /// </summary>
        [Required]
        [StringLength(200)]
        public string TaskDescription { get; set; }

        /// <summary>
        /// Date task created
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now.AddHours(7);

        /// <summary>
        /// Estimate complete time
        /// </summary>
        public int EstimateTime { get; set; } = 0;

        /// <summary>
        /// Real time complete task
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

        /// <summary>
        /// Plan topic id this task belong to
        /// </summary>
        [Required]
        public int PlanTopicId { get; set; }

        /// <summary>
        /// Task category id this task belong to
        /// </summary>
        [Required]
        public int TaskCategoryId { get; set; }
    }
}
