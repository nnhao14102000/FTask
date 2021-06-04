﻿using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class MajorRepository : GenericRepository<Major>, IMajorRepository
    {
        public FTaskContext context { get; set; }
        public MajorRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }

        public Major GetMajorByMajorId(string id)
        {
            return FindByCondition(major => major.MajorId.Equals(id)).FirstOrDefault();
        }

        public PagedList<Major> GetMajors(MajorParameters majorParameters)
        {
            var major = FindAll();
            SearchByName(ref major, majorParameters.MajorName);

            return PagedList<Major>.ToPagedList(major,
                majorParameters.PageNumber, majorParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Major> majors, string name)
        {
            if (!majors.Any() || string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            majors = majors.Where(st => st.MajorName.ToLower().Contains(name.Trim().ToLower()));
        }
    }
}
