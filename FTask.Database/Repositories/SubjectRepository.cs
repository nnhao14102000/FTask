using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FTask.Database.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private FTaskContext context { get; set; }

        public SubjectRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }

        public Subject GetSubjectBySubjecId(string id)
        {
            return FindByCondition(subject
                => subject.SubjectId.Equals(id)).OrderBy(s => s.SubjectId).FirstOrDefault();
        }

        public Subject GetSubjectInDetailBySubjecId(string id)
        {
            var subject = FindByCondition(subject
                => subject.SubjectId.Equals(id)).FirstOrDefault();

            context.Entry(subject)
                .Collection(s => s.Topics)
                .Query()
                .OrderBy(t => t.TopicId)
                .Load();
            return subject;
        }

        public PagedList<Subject> GetSubjects(SubjectParameters subjectParameters)
        {
            var subjects = FindAll();

            FilterBySubjectGroup(ref subjects, subjectParameters.SubjectGroupId);
            SearchByName(ref subjects, subjectParameters.SubjectName);
            SearchById(ref subjects, subjectParameters.SubjectId);

            return PagedList<Subject>
                .ToPagedList(subjects.OrderBy(s => s.SubjectName)
                    , subjectParameters.PageNumber
                    , subjectParameters.PageSize);
        }

        private void FilterBySubjectGroup(ref IQueryable<Subject> subjects, int subjectGroupId)
        {
            if (!subjects.Any() || subjectGroupId == 0)
            {
                return;
            }
            subjects = subjects
                .Where(s => s.SubjectGroupId == subjectGroupId);
        }

        private void SearchByName(ref IQueryable<Subject> subjects, string subjectName)
        {
            if (!subjects.Any() || string.IsNullOrWhiteSpace(subjectName))
            {
                return;
            }
            subjects = subjects
                .Where(s => s.SubjectName.ToLower()
                .Contains(subjectName.Trim().ToLower()));
        }
        private void SearchById(ref IQueryable<Subject> subjects, string subjectId)
        {
            if (!subjects.Any() || string.IsNullOrWhiteSpace(subjectId))
            {
                return;
            }
            subjects = subjects
                .Where(s => s.SubjectId.ToLower()
                .Contains(subjectId.Trim().ToLower()));
        }
    }
}
