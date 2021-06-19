using System;

namespace FTask.Api.ViewModels.TaskViewModels
{
    public class TaskReadViewModel
    {
        public int TaskId { get; set; }
        /// <summary>
        /// Date task created
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now.AddHours(7);

        /// <summary>
        /// Estimate complete time
        /// </summary>
        public int EstimateTime { get; set; } = 0;

        /// <summary>
        /// Real time completet task
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
    }
}
