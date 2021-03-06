using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Database.Models
{
    public partial class TaskCategory
    {
        public TaskCategory()
        {
            Tasks = new HashSet<Task>();
        }

        public int TaskCategoryId { get; set; }
        public string TaskType { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
