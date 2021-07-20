using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.PlanTopicBusinessService
{
    public class PlanTopicService : IPlanTopicService
    {
        private readonly IPlanTopicRepository _planTopicRepository;
        private readonly ILogger<PlanTopicService> _log;

        public PlanTopicService(IPlanTopicRepository planTopicRepository, ILogger<PlanTopicService> log)
        {
            _planTopicRepository = planTopicRepository;
            _log = log;
        }

        public void AddPlanTopic(PlanTopic planTopic)
        {
            _log.LogInformation($"Add PlanTopic {planTopic.PlanTopicId} into database...");
            _planTopicRepository.Add(planTopic);
            try
            {
                if (_planTopicRepository.SaveChanges(planTopic))
                {
                    _log.LogInformation($"Add PlanTopic {planTopic.PlanTopicId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"Add PlanTopic {planTopic.PlanTopicId} fail with error: {e.Message}");
            }
        }

        public PagedList<PlanTopic> GetAllPlanTopics(PlanTopicParameters planTopicParameters)
        {
            var planTopic = _planTopicRepository.GetPlanTopics(planTopicParameters);
            if (planTopic is null)
            {
                _log.LogInformation("Have no PlanTopic...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {planTopic.TotalCount} PlanTopic from database...");
                return planTopic;
            }

        }

        public PlanTopic GetPlanTopicByPlanTopicId(int Id)
        {
            _log.LogInformation($"Search PlanTopic {Id}...");
            var planTopic = _planTopicRepository.GetPlanTopicByPlanTopicId(Id);
            if (planTopic is null)
            {
                _log.LogInformation($"Can not found PlanTopic {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success PlanTopic {Id}...");
                return planTopic;
            }
        }

        public void RemovePlanTopic(PlanTopic planTopic)
        {
            _log.LogInformation($"Remove PlanTopic {planTopic.PlanTopicId}...");
            _planTopicRepository.Remove(planTopic);
            try
            {
                if (_planTopicRepository.SaveChanges(planTopic))
                {
                    _log.LogInformation($"Remove PlanTopic {planTopic.PlanTopicId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove PlanTopic {planTopic.PlanTopicId} fail with error: {e.Message}");
            }
        }

        public void UpdatePlanTopic(PlanTopic planTopic)
        {
            _log.LogInformation($"Update PlanTopic {planTopic.PlanTopicId}...");
            _planTopicRepository.Update(planTopic);
            try
            {
                if (_planTopicRepository.SaveChanges(planTopic))
                {
                    _log.LogInformation($"Update PlanTopic {planTopic.PlanTopicId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update PlanTopic {planTopic.PlanTopicId} fail with error: {e.Message}");
            }
        }

    }
}
