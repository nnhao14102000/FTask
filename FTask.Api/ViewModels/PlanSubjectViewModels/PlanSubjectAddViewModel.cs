using System;

namespace FTask.Api.ViewModels.PlanSubjectViewModels
{
    public class PlanSubjectAddViewModel
    {
        public int Priority { get; set; } = 0;
        public int Progress { get; set; } = 0;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false;
        public int PlanSemesterId { get; set; }
        public string SubjectId { get; set; }
    }
}
