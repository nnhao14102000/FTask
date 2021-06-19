using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class PlanSubject
    {
        public PlanSubject()
        {
            PlanTopics = new HashSet<PlanTopic>();
        }

        public int PlanSubjectId { get; set; }
        public int? Priority { get; set; }
        public int? Progress { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsComplete { get; set; }
        public int PlanSemesterId { get; set; }
        public string SubjectId { get; set; }

        public virtual PlanSemester PlanSemester { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<PlanTopic> PlanTopics { get; set; }
    }
}
