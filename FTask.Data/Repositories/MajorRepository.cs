using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class MajorRepository : GenericRepository<Major>, IMajorRepository
    {
        private FTaskContext context { get; set; }
        public MajorRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }

        public Major GetMajorByMajorId(string id)
        {
            return FindByCondition(major
                => major.MajorId.Equals(id)).FirstOrDefault();
        }

        public Major GetMajorInDetailByMajorId(string id)
        {
            var major = FindByCondition(major
                => major.MajorId.Equals(id)).FirstOrDefault();

            context.Entry(major)
                .Collection(m => m.Students)
                .Query()
                .OrderBy(st => st.StudentName)
                .Load();

            return major;
        }

        public PagedList<Major> GetMajors(MajorParameters majorParameters)
        {
            var major = FindAll();
            SearchByName(ref major, majorParameters.MajorName);

            return PagedList<Major>.ToPagedList(major.OrderBy(m => m.MajorId),
                majorParameters.PageNumber, majorParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Major> majors, string name)
        {
            if (!majors.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            majors = majors
                .Where(st => st.MajorName.ToLower()
                .Contains(name.Trim().ToLower()));
        }
    }
}
