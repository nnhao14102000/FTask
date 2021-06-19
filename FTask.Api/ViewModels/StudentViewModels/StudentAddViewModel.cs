using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.StudentViewModels
{
    /// <summary>
    /// Student add model
    /// </summary>
    public class StudentAddViewModel
    {
        /// <summary>
        /// Student Id, not null, max length = 20
        /// </summary>
        [Required]
        [StringLength(20)]
        public string StudentId { get; set; }

        /// <summary>
        /// Student name, not null, max length = 50
        /// </summary>
        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        /// <summary>
        /// Student email, not null, max length = 50
        /// </summary>
        [Required]
        [StringLength(50)]
        public string StudentEmail { get; set; }

        /// <summary>
        /// Major Id this student belong to, not null, max length = 20
        /// </summary>
        [Required]
        [StringLength(20)]
        public string MajorId { get; set; }
    }
}
