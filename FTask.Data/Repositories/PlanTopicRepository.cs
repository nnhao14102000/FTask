﻿using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class PlanTopicRepository : GenericRepository<PlanTopic>, IPlanTopicRepository
    {
        private FTaskContext context;
        public PlanTopicRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }
        public PlanTopic GetPlanTopicByPlanTopicId(int id)
        {
            return FindByCondition(x => x.PlanTopicId == id).FirstOrDefault();
        }

        public PagedList<PlanTopic> GetPlanTopics(PlanTopicParameters planTopicParameters)
        {
            return PagedList<PlanTopic>
                .ToPagedList(FindAll(), planTopicParameters.PageNumber, planTopicParameters.PageSize);
        }
    }
}
