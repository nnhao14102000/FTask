using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.TopicViewModels
{
    /// <summary>
    /// Topic update view model
    /// </summary>
    public class TopicUpdateViewModel
    {
        /// <summary>
        /// Topic name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TopicName { get; set; }

        /// <summary>
        /// Topic description, can be null
        /// </summary>
        [StringLength(200)]
        public string TopicDescription { get; set; }

        /// <summary>
        /// Subject Id
        /// </summary>
        [Required]
        [StringLength(10)]
        public string SubjectId { get; set; }
    }
}
