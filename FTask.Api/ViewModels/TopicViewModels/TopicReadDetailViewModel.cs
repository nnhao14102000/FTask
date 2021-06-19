namespace FTask.Api.ViewModels.TopicViewModels
{
    /// <summary>
    /// Topic read detail view model
    /// </summary>
    public class TopicReadDetailViewModel
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
        public string TopicDescription { get; set; }

        /// <summary>
        /// Subject Id
        /// </summary>
        public string SubjectId { get; set; }
    }
}
