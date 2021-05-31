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

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MajorId { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<PlanSemester> PlanSemesters { get; set; }
    }
}
