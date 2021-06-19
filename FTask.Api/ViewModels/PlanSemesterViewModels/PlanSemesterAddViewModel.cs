using System;

namespace FTask.Api.ViewModels.PlanSemesterViewModels
{
    public class PlanSemesterAddViewModel
    {
        public string PlanSemesterName { get; set; } = "Unknown Plan Semester";
        public string StudentId { get; set; }
        public string SemesterId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsComplete { get; set; } = false;
    }
}
