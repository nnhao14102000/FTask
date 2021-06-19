using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.MajorViewModels
{
    /// <summary>
    /// Major update model
    /// </summary>
    public class MajorUpdateViewModel
    {
        /// <summary>
        /// Major Name, required, max length 50
        /// </summary>
        [Required]
        [StringLength(50)]
        public string MajorName { get; set; }
    }
}
