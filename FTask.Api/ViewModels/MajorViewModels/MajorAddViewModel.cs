using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.MajorViewModels
{
    /// <summary>
    /// Major add model
    /// </summary>
    public class MajorAddViewModel
    {
        /// <summary>
        /// Major Id, required, max length 20 
        /// </summary>
        [Required]
        [StringLength(20)]
        public string MajorId { get; set; }

        /// <summary>
        /// Major Name, required, max length 50
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string MajorName { get; set; }
    }
}
