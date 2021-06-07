using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using System.Linq;

namespace FTask.Data.Repositories
{
    class SubjectGroupRepository : GenericRepository<SubjectGroup>, ISubjectGroupRepository
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
            var subjectGroup = FindAll();
            SearchByName(ref subjectGroup, subjectGroupParametes.SubjectGroupName);

            return PagedList<SubjectGroup>.ToPagedList(subjectGroup, subjectGroupParametes.PageNumber, subjectGroupParametes.PageSize);
        }

        private void SearchByName(ref IQueryable<SubjectGroup> subjectGroup, string name)
        {
            if(!subjectGroup.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            subjectGroup = subjectGroup.Where(sg => sg.SubjectGroupName.ToLower().Contains(name.Trim().ToLower()));
        }

        
    }
}
