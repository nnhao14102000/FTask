namespace FTask.Api.ViewModels.SubjectViewModels
{
    /// <summary>
    /// Topics in subject read view model
    /// </summary>
    public class TopicsInSubjectReadViewModel
    {
        /// <summary>
        /// Topic Id
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Topic name
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// Topic description, can be null
        /// </summary>
        public string? TopicDescription { get; set; }
    }
}
