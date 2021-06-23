using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Database.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public string MajorId { get; set; }
        public string MajorName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
