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
        public string StudentName { get; set; }

        /// <summary>
        /// Major id this student belong to
        /// </summary>
        public string MajorId { get; set; }
    }
}
