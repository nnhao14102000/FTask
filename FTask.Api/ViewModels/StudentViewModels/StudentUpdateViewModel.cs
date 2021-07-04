using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.StudentViewModels
{
    /// <summary>
    /// Student update model
    /// </summary>
    public class StudentUpdateViewModel
    {
        /// <summary>
        /// Student name
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string StudentName { get; set; }

        /// <summary>
        /// Major id this student belong to
        /// </summary>
        [Required]
        [StringLength(20)]
        public string MajorId { get; set; }
    }
}
