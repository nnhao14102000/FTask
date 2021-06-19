using System;
using System.ComponentModel.DataAnnotations;

namespace FTask.Api.ViewModels.PlanSubjectViewModels
{
    /// <summary>
    /// Plan subject create view model
    /// </summary>
    public class PlanSubjectAddViewModel
    {
        /// <summary>
        /// Priority of plan subject
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = ("Can only bettween 0...Max int"))]
        public int Priority { get; set; } = 0;

        /// <summary>
        /// plan subject progress
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = ("Can only bettween 0...Max int"))]
        public int Progress { get; set; } = 0;

        /// <summary>
        /// Plan subject date created, not null
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Is plan subject complete, not null
        /// </summary>
        [Required]
        public bool IsComplete { get; set; } = false;

        /// <summary>
        /// Plan semester id this plan belong to, not null
        /// </summary>
        [Required]
        public int PlanSemesterId { get; set; }

        /// <summary>
        /// Subject id of subject this plan belong to, not null
        /// </summary>
        [Required]
        [StringLength(10)]
        public string SubjectId { get; set; }
    }
}
