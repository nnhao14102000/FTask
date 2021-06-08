using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class SubjectGroupRepository : GenericRepository<SubjectGroup>, ISubjectGroupRepository
    {
        public FTaskContext context { get; set; }

        public SubjectGroupRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }

        public SubjectGroup GetSubjectGroupBySubjectGroupId(int Id)
        {
            return FindByCondition(subjectGroup => subjectGroup.SubjectGroupId.Equals(Id)).FirstOrDefault();
        }

        public PagedList<SubjectGroup> GetSubjectGroups(SubjectGroupParametes subjectGroupParametes)
        {
            var subjectGroups = FindAll();
            SearchByName(ref subjectGroups, subjectGroupParametes.SubjectGroupName);

            return PagedList<SubjectGroup>.ToPagedList(subjectGroups.OrderBy(sg => sg.SubjectGroupName), subjectGroupParametes.PageNumber, subjectGroupParametes.PageSize);
        }

        private void SearchByName(ref IQueryable<SubjectGroup> subjectGroups, string name)
        {
            if(!subjectGroups.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            subjectGroups = subjectGroups.Where(sg => sg.SubjectGroupName.ToLower().Contains(name.Trim().ToLower()));
        }

        
    }
}
