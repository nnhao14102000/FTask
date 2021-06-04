using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class Topic
    {
        public Topic()
        {
            PlanTopics = new HashSet<PlanTopic>();
        }

        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string Decription { get; set; }
        public string SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<PlanTopic> PlanTopics { get; set; }
    }
}
