using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using System.Linq;

namespace FTask.Database.Repositories
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        private FTaskContext context { get; set; }
        public SemesterRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }

        public PagedList<Semester> GetSemesters(SemesterParameters semesterParameters)
        {
            var semesters = FindAll();

            SearchByName(ref semesters, semesterParameters.SemesterName);

            return PagedList<Semester>.ToPagedList(semesters,
                semesterParameters.PageNumber, semesterParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Semester> semester, string name)
        {
            if (!semester.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            semester = semester
                .Where(st => st.SemesterName.ToLower()
                .Contains(name.Trim().ToLower()));
        }

        public Semester GetSemesterBySemesterId(string id)
        {
            return FindByCondition(semester
                => semester.SemesterId.Equals(id)).FirstOrDefault();
        }
    }
}
