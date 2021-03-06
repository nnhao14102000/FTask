using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Database.Models
{
    public partial class Topic
    {
        public Topic()
        {
            PlanTopics = new HashSet<PlanTopic>();
        }

        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public string SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<PlanTopic> PlanTopics { get; set; }
    }
}
