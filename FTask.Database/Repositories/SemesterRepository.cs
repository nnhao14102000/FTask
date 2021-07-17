using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using System;
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
            FilterByIsComplete(ref semesters, semesterParameters.IsComplete);

            return PagedList<Semester>.ToPagedList(semesters,
                semesterParameters.PageNumber, semesterParameters.PageSize);
        }

        private void FilterByIsComplete(ref IQueryable<Semester> semesters, bool? isComplete)
        {
            if (!semesters.Any() || isComplete is null)
            {
                return;
            }
            semesters = semesters
                    .Where(x => x.IsComplete == isComplete);
        }

        private void SearchByName(ref IQueryable<Semester> semesters, string name)
        {
            if (!semesters.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            semesters = semesters
                .Where(x => x.SemesterName.ToLower()
                .Contains(name.Trim().ToLower()));
        }

        public Semester GetSemesterBySemesterId(string id)
        {
            return FindByCondition(semester
                => semester.SemesterId.Equals(id)).FirstOrDefault();
        }
    }
}
