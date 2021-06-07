using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTask.Data.Repositories.IRepository
{
   public interface ISubjectGroupRepository : IGenericRepository<SubjectGroup>
    {
        PagedList<SubjectGroup> GetSubjectGroups(SubjectGroupParametes subjectGroupParameters);

        SubjectGroup GetSubjectGroupBySubjectGroupId(int id);
    }
}
