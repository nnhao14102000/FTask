using System;

namespace FTask.Api.ViewModels.TaskViewModels
{
    public class TaskAddViewModel
    {
        public string TaskDescription { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.AddHours(7);
        public int EstimateTime { get; set; } = 0;
        public int EffortTime { get; set; } = 0;
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; } = 0;
        public bool Status { get; set; } = false;
        public int PlanTopic { get; set; }
        public int TaskCategoryId { get; set; }
    }
}
