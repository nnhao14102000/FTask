using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.SubjectGroupViewModels
{
    /// <summary>
    /// Subject add model
    /// </summary>
    public class SubjectGroupAddViewModel
    {
        /// <summary>
        /// Subject group name, not null, max length = 50
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string SubjectGroupName { get; set; }
    }
}
