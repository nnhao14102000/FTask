using System;

namespace FTask.Api.ViewModels.PlanSubjectViewModels
{
    public class PlanSubjectReadDetailViewModel
    {
        public int PlanSubjectId { get; set; }
        public int Priority { get; set; }
        public int Progress { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsComplete { get; set; }
        public int PlanSemesterId { get; set; }
        public string SubjectId { get; set; }
    }
}
