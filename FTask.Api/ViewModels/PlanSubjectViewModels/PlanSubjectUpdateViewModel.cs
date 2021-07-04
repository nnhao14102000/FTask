using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.PlanSubjectViewModels
{
    /// <summary>
    /// Plan subject update view model
    /// </summary>
    public class PlanSubjectUpdateViewModel
    {
        /// <summary>
        /// Plan subject priority
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage =("Can only bettween 0...Max int"))]
        public int Priority { get; set; }

        /// <summary>
        /// Plan progress
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage =("Can only bettween 0...Max int"))]
        public int Progress { get; set; }

        /// <summary>
        /// Is plan subject complete, not null
        /// </summary>
        [Required]
        public bool IsComplete { get; set; }
    }
}
