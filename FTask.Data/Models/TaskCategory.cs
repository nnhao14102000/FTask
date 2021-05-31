using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class TaskCategory
    {
        public TaskCategory()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string TaskType { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
