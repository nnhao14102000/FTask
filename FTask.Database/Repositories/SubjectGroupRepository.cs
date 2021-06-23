using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FTask.Database.Repositories
{
    public class SubjectGroupRepository : GenericRepository<SubjectGroup>, ISubjectGroupRepository
    {
        private FTaskContext context { get; set; }

        public SubjectGroupRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }

        public SubjectGroup GetSubjectGroupBySubjectGroupId(int Id)
        {
            var subjectGroup = FindByCondition(subjectGroup
                => subjectGroup.SubjectGroupId.Equals(Id)).FirstOrDefault();

            context.Entry(subjectGroup)
                .Collection(sg => sg.Subjects)
                .Query()
                .OrderBy(s => s.SubjectName)
                .Load();

            return subjectGroup;
        }

        public PagedList<SubjectGroup> GetSubjectGroups(
            SubjectGroupParameters subjectGroupParameters)
        {
            var subjectGroups = FindAll();
            SearchByName(ref subjectGroups, subjectGroupParameters.SubjectGroupName);

            return PagedList<SubjectGroup>
                .ToPagedList(subjectGroups.OrderBy(sg => sg.SubjectGroupId)
                    , subjectGroupParameters.PageNumber
                    , subjectGroupParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<SubjectGroup> subjectGroups, string name)
        {
            if (!subjectGroups.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            subjectGroups = subjectGroups
                .Where(sg => sg.SubjectGroupName.ToLower()
                .Contains(name.Trim().ToLower()));
        }


    }
}
