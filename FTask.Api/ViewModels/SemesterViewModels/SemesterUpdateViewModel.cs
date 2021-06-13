using System;

namespace FTask.Api.ViewModels.SemesterViewModels
{
    public class SemesterUpdateViewModel
    {
        public string SemesterName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
    }
}
