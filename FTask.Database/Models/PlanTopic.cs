using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Database.Models
{
    public partial class PlanTopic
    {
        public PlanTopic()
        {
            Tasks = new HashSet<Task>();
        }

        public int PlanTopicId { get; set; }
        public int? Progress { get; set; }
        public bool IsComplete { get; set; }
        public int TopicId { get; set; }
        public int PlanSubjectId { get; set; }

        public virtual PlanSubject PlanSubject { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
