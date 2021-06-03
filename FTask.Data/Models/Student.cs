using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            PlanSemesters = new HashSet<PlanSemester>();
        }

        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string MajorId { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<PlanSemester> PlanSemesters { get; set; }
    }
}
