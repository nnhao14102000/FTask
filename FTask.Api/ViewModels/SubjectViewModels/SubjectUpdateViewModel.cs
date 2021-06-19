using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.SubjectViewModels
{
    /// <summary>
    /// Subject update model
    /// </summary>
    public class SubjectUpdateViewModel
    {
        /// <summary>
        /// Subject name, not null, max length = 50
        /// </summary>
        [Required]
        [StringLength(50)]
        public string SubjectName { get; set; }

        /// <summary>
        /// Subject source, not null, max length = 50
        /// </summary>
        [StringLength(50)]
        public string Source { get; set; }

        /// <summary>
        /// Subject groub id this subject belong to, not null
        /// </summary>
        [Required]
        public int SubjectGroupId { get; set; }
    }
}
