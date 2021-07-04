using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.PlanSemesterViewModels
{
    /// <summary>
    /// Plan semester update view model
    /// </summary>
    public class PlanSemesterUpdateViewModel
    {
        /// <summary>
        /// Plan semester name, allow null, max length = 50
        /// </summary>
        [StringLength(50)]
        public string PlanSemesterName { get; set; }

        /// <summary>
        /// Is complete plan in semester, not null 
        /// </summary>
        [Required]
        public bool IsComplete { get; set; }
    }
}
