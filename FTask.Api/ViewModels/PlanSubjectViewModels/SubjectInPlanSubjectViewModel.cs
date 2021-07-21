namespace FTask.Api.ViewModels.PlanSubjectViewModels
{
    /// <summary>
    /// Subject in plan subject
    /// </summary>
    public class SubjectInPlanSubjectViewModel
    {
        /// <summary>
        /// Subject Id
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// Subject name
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Subject source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Subject group id this subject belong to
        /// </summary>
        public int SubjectGroupId { get; set; }
    }
}