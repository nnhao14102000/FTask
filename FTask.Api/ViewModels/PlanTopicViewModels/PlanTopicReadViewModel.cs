﻿namespace FTask.Api.ViewModels.PlanTopicViewModels
{
    public class PlanTopicReadViewModel
    {
        public int PlanTopicId { get; set; }
        public int Progress { get; set; }
        public bool Status { get; set; }
        public int TopicId { get; set; }
        public int PlanSubjectId { get; set; }
    }
}