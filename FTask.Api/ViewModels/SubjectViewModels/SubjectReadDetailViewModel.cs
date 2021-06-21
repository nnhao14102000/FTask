using System.Collections.Generic;

namespace FTask.Api.ViewModels.SubjectViewModels
{
    /// <summary>
    /// Read Subject detail model
    /// </summary>
    public class SubjectReadDetailViewModel
    {
        /// <summary>
        /// Subject Id
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// Subject name
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Subject source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Subject groub id this subject belong to
        /// </summary>
        public int SubjectGroupId { get; set; }

        /// <summary>
        /// Topics in Subject....
        /// </summary>
        public ICollection<TopicsInSubjectReadViewModel> Topics { get; set; }
    }
}
