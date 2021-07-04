using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.PlanTopicViewModels
{
    /// <summary>
    /// Plan topic add view model
    /// </summary>
    public class PlanTopicAddViewModel
    {
        /// <summary>
        /// Plan topic progress
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = ("Can only bettween 0...Max int"))]
        public int Progress { get; set; }

        /// <summary>
        /// Is plan complete, not null
        /// </summary>
        [Required]
        public bool IsComplete { get; set; }

        /// <summary>
        /// Topic id this plan belong to, not null
        /// </summary>
        [Required]
        public int TopicId { get; set; }

        /// <summary>
        /// Plan subject id this plan belong to, not null
        /// </summary>
        [Required]
        public int PlanSubjectId { get; set; }
    }
}
