﻿namespace FTask.Api.ViewModels.TopicViewModels
{
    /// <summary>
    /// Topic add view model
    /// </summary>
    public class TopicAddViewModel
    {
        /// <summary>
        /// Topic name
        /// </summary>
        public string TopicName { get; set; }
        /// <summary>
        /// Topic description, can be null
        /// </summary>
        public string? TopicDescription { get; set; }
        /// <summary>
        /// Subject Id
        /// </summary>
        public string SubjectId { get; set; }
    }
}
