using System;
using System.Collections.Generic;

#nullable disable

namespace FTask.Data.Models
{
    public partial class SubjectGroup
    {
        public SubjectGroup()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
