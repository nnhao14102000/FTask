using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
