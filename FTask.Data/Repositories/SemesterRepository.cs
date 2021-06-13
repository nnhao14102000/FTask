using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using System.Linq;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        public FTaskContext context { get; set; }
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
