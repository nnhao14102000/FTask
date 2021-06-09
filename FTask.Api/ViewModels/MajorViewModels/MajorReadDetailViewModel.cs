using System.Collections.Generic;

namespace FTask.Api.ViewModels.MajorViewModels
{
    public class MajorReadDetailViewModel
    {
        public string MajorId { get; set; }
        public string MajorName { get; set; }
        public ICollection<StudentOfMajorViewModel> Students { get; set; }
    }
}
