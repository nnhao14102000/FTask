using System.Collections.Generic;

namespace FTask.Api.ViewModels.MajorViewModels
{
    /// <summary>
    /// Read major detail model
    /// </summary>
    public class MajorReadDetailViewModel
    {
        /// <summary>
        /// Major Id
        /// </summary>
        public string MajorId { get; set; }
        /// <summary>
        /// Major name
        /// </summary>
        public string MajorName { get; set; }
        /// <summary>
        /// List of Student in belong to major
        /// </summary>
        public ICollection<StudentOfMajorViewModel> Students { get; set; }
    }
}
