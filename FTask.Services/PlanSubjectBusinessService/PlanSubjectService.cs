using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.PlanSubjectBusinessService
{
    public class PlanSubjectService : IPlanSubjectService
    {
        private readonly IPlanSubjectRepository _planSubjectRepository;
        private readonly ILogger<PlanSubjectService> _log;

        public PlanSubjectService(IPlanSubjectRepository planSubjectRepository, ILogger<PlanSubjectService> log)
        {
            _planSubjectRepository = planSubjectRepository;
            _log = log;
        }

        public void AddPlanSubject(PlanSubject planSubject)
        {
            _log.LogInformation($"Add PlanSubject {planSubject.PlanSubjectId} into database...");
            _planSubjectRepository.Add(planSubject);
            try
            {
                if (_planSubjectRepository.SaveChanges())
                {
                    _log.LogInformation($"Add PlanSubject {planSubject.PlanSubjectId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"Add PlanSubject {planSubject.PlanSubjectId} fail with error: {e.Message}");
            }
        }

        public PagedList<PlanSubject> GetAllPlanSubjects(PlanSubjectParameters planSubjectPrameters)
        {
            var PlanSubject = _planSubjectRepository.GetPlanSubjects(planSubjectPrameters);
            if (PlanSubject is null)
            {
                _log.LogInformation("Have no PlanSubject...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {PlanSubject.TotalCount} PlanSubject from database...");
                return PlanSubject;
            }

        }

        public PlanSubject GetPlanSubjectByPlanSubjectId(int Id)
        {
            _log.LogInformation($"Search PlanSubject {Id}...");
            var PlanSubject = _planSubjectRepository.GetPlanSubjectByPlanSubjectId(Id);
            if (PlanSubject is null)
            {
                _log.LogInformation($"Can not found PlanSubject {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success PlanSubject {Id}...");
                return PlanSubject;
            }
        }

        public void RemovePlanSubject(PlanSubject planSubject)
        {
            _log.LogInformation($"Remove PlanSubject {planSubject.PlanSubjectId}...");
            _planSubjectRepository.Remove(planSubject);
            try
            {
                if (_planSubjectRepository.SaveChanges())
                {
                    _log.LogInformation($"Remove PlanSubject {planSubject.PlanSubjectId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove PlanSubject {planSubject.PlanSubjectId} fail with error: {e.Message}");
            }
        }

        public void UpdatePlanSubject(PlanSubject planSubject)
        {
            _log.LogInformation($"Update PlanSubject {planSubject.PlanSubjectId}...");
            _planSubjectRepository.Update(planSubject);
            try
            {
                if (_planSubjectRepository.SaveChanges())
                {
                    _log.LogInformation($"Update PlanSubject {planSubject.PlanSubjectId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update PlanSubject {planSubject.PlanSubjectId} fail with error: {e.Message}");
            }
        }

    }
}
