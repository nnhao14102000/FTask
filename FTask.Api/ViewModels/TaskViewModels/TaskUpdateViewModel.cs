using System;

namespace FTask.Api.ViewModels.TaskViewModels
{
    public class TaskUpdateViewModel
    {
        public string TaskDescription { get; set; }
        public int EstimateTime { get; set; }
        public int EffortTime { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }
    }
}
