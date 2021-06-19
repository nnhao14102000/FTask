using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class Semester
    {
        public Semester()
        {
            PlanSemesters = new HashSet<PlanSemester>();
        }

        public string SemesterId { get; set; }
        public string SemesterName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsComplete { get; set; }

        public virtual ICollection<PlanSemester> PlanSemesters { get; set; }
    }
}
