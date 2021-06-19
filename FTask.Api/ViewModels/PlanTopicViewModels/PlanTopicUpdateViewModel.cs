using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.PlanTopicViewModels
{
    /// <summary>
    /// Plan topic update view model
    /// </summary>
    public class PlanTopicUpdateViewModel
    {
        /// <summary>
        /// Plan progress
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage =("Can only bettween 0...Max int"))]
        public int Progress { get; set; }

        /// <summary>
        /// Is plan complete
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
