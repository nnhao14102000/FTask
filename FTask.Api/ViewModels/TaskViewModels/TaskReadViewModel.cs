using System;

namespace FTask.Api.ViewModels.TaskViewModels
{
    /// <summary>
    /// Task Read View Model
    /// </summary>
    public class TaskReadViewModel
    {
        /// <summary>
        /// Task Id
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Task Description
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Date task created
        /// </summary>
        public DateTime CreateDate { get; set; }

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
        public int Priority { get; set; } = 0;

        /// <summary>
        /// Is task complete
        /// </summary>
        public bool IsComplete { get; set; } = false;

        /// <summary>
        /// Plan topic id this task belong to
        /// </summary>
        public int PlanTopicId { get; set; }

        /// <summary>
        /// Task category id this task belong to
        /// </summary>
        public int TaskCategoryId { get; set; }

        /// <summary>
        /// Task category
        /// </summary>
        public TaskCategoryViewModels.TaskCategoryReadDetailViewModel TaskCategory {get;set;}
    }
}
