﻿using System;

namespace FTask.Api.ViewModels.SemesterViewModels
{
    /// <summary>
    /// Semester update view model
    /// </summary>
    public class SemesterUpdateViewModel
    {
        /// <summary>
        /// Semester Name
        /// </summary>
        public string SemesterName { get; set; }
        /// <summary>
        /// The begin day of semester
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// The end day of semester
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Status: done or not
        /// </summary>
        public int? Status { get; set; }
    }
}
