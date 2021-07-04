using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.TaskCategoryViewModels
{
    /// <summary>
    /// Task category update view model
    /// </summary>
    public class TaskCategoryUpdateViewModel
    {
        /// <summary>
        /// Task type, not null, max length 50
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string TaskType { get; set; }
    }
}
