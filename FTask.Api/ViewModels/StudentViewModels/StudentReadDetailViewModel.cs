namespace FTask.Api.ViewModels.StudentViewModels
{
    /// <summary>
    /// Student read detail view model
    /// </summary>
    public class StudentReadDetailViewModel
    {
        /// <summary>
        /// Student Id
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// Student name
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Student email
        /// </summary>
        public string StudentEmail { get; set; }

        /// <summary>
        /// Major id this student belong to
        /// </summary>
        public string MajorId { get; set; }
    }
}
    