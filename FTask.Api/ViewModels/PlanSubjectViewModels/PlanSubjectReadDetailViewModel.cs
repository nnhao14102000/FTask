﻿using FTask.Api.ViewModels.PlanTopicViewModels;
using System;
using System.Collections.Generic;

namespace FTask.Api.ViewModels.PlanSubjectViewModels
{
    /// <summary>
    /// Plan subject read detail view model
    /// </summary>
    public class PlanSubjectReadDetailViewModel
    {
        /// <summary>
        /// Plan subject id
        /// </summary>
        public int PlanSubjectId { get; set; }

        /// <summary>
        /// Plan subject priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Plan subject progress
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Plan subject date created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Is plan subject complete
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Plan semester id of that plan subject belong to
        /// </summary>
        public int PlanSemesterId { get; set; }

        /// <summary>
        /// Subject id of subject that plan subject belong to
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// PlanTopics in PlanSubject
        /// </summary>
        public ICollection<PlanTopicReadDetailViewModel> PlanTopics { get; set; }
    }
}
