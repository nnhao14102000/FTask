using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string Decription { get; set; }
        public DateTime CreateDate { get; set; }
        public long? EstimateTime { get; set; }
        public long? EffortTime { get; set; }
        public int? Priority { get; set; }
        public int? Status { get; set; }
        public int? PlanTopicId { get; set; }
        public int? TaskCategoryId { get; set; }

        public virtual PlanTopic PlanTopic { get; set; }
        public virtual TaskCategory TaskCategory { get; set; }
    }
}
