using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.TaskCategoryViewModels
{
    /// <summary>
    /// Task category add view model
    /// </summary>
    public class TaskCategoryAddViewModel
    {
        /// <summary>
        /// Task type, not null, max length 50
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TaskType { get; set; }
    }
}
