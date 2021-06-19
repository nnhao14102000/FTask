using System;

namespace FTask.Api.ViewModels.PlanSemesterViewModels
{
    public class PlanSemesterReadViewModel
    {
        public int PlanSemesterId { get; set; }
        public string PlanSemesterName { get; set; }
        public string StudentId { get; set; }
        public string SemesterId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
