using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.SubjectGroupViewModels
{
    /// <summary>
    /// Subject group view model
    /// </summary>
    public class SubjectGroupUpdateViewModel
    {
        /// <summary>
        /// Subject group name
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string SubjectGroupName { get; set; }
    }
}
