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

        public int SubjectGroupId { get; set; }
        public string SubjectGroupName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
