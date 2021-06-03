using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class Subject
    {
        public Subject()
        {
            PlanSubjects = new HashSet<PlanSubject>();
            Topics = new HashSet<Topic>();
        }

        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Source { get; set; }
        public int? SubjectGroupId { get; set; }

        public virtual SubjectGroup SubjectGroup { get; set; }
        public virtual ICollection<PlanSubject> PlanSubjects { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
