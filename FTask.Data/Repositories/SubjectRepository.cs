using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public FTaskContext context { get; set; }

        public SubjectRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }

        public Subject GetSubjectBySubjecId(string id)
        {
            return FindByCondition(subject 
                => subject.SubjectId.Equals(id)).FirstOrDefault();
        }

        public PagedList<Subject> GetSubjects(SubjectParameters subjectParameters)
        {
            var subjects = FindAll();
            SearchByName(ref subjects, subjectParameters.SubjectName);

            return PagedList<Subject>
                .ToPagedList(subjects.OrderBy(s=> s.SubjectName)
                    , subjectParameters.PageNumber
                    , subjectParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Subject> subjects, string subjectName)
        {
            if (!subjects.Any() || string.IsNullOrWhiteSpace(subjectName))
            {
                return;
            }
            subjects = subjects
                .Where(s=> s.SubjectName.ToLower()
                .Contains(subjectName.Trim().ToLower()));
        }
    }
}
