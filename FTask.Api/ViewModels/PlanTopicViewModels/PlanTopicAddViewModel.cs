﻿namespace FTask.Api.ViewModels.PlanTopicViewModels
{
    public class PlanTopicAddViewModel
    {
        public int Progress { get; set; }
        public bool IsComplete { get; set; }
        public int TopicId { get; set; }
        public int PlanSubjectId { get; set; }
    }
}
