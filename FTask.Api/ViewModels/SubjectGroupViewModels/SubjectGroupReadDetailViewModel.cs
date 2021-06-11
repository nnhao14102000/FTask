using System.Collections.Generic;

namespace FTask.Api.ViewModels.SubjectGroupViewModels
{
    /// <summary>
    /// Subject group read detail view model
    /// </summary>
    public class SubjectGroupReadDetailViewModel
    {
        /// <summary>
        /// Subject group Id
        /// </summary>
        public int SubjectGroupId { get; set; }
        /// <summary>
        /// Subject group name
        /// </summary>
        public string SubjectGroupName { get; set; }
        /// <summary>
        /// List of subject belong to subject group
        /// </summary>
        public ICollection<SubjectsOfSubjectGroupViewModel> Subjects { get; set; }
    }
}
