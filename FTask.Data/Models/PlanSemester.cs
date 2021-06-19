using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class PlanSemester
    {
        public PlanSemester()
        {
            PlanSubjects = new HashSet<PlanSubject>();
        }

        public int PlanSemesterId { get; set; }
        public string PlanSemesterName { get; set; }
        public string StudentId { get; set; }
        public string SemesterId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsComplete { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<PlanSubject> PlanSubjects { get; set; }
    }
}
