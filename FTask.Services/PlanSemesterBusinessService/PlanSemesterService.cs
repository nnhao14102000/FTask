using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.PlanSemesterBusinessService
{
    public class PlanSemesterService : IPlanSemesterService
    {
        private readonly IPlanSemesterRepository _planSemesterRepository;
        private readonly ILogger<PlanSemesterService> _log;

        public PlanSemesterService(IPlanSemesterRepository planSemesterRepository, ILogger<PlanSemesterService> log)
        {
            _planSemesterRepository = planSemesterRepository;
            _log = log;
        }

        public void AddPlanSemester(PlanSemester planSemester)
        {
            _log.LogInformation($"Add PlanSemester {planSemester.PlanSemesterName} into database...");
            _planSemesterRepository.Add(planSemester);
            try
            {
                if (_planSemesterRepository.SaveChanges())
                {
                    _log.LogInformation($"Add PlanSemester {planSemester.PlanSemesterName} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"Add PlanSemester {planSemester.PlanSemesterName} fail with error: {e.Message}");
            }
        }

        public PagedList<PlanSemester> GetAllPlanSemesters(PlanSemesterParameters planSemesterPrameters)
        {
            var planSemester = _planSemesterRepository.GetPlanSemesters(planSemesterPrameters);
            if (planSemester is null)
            {
                _log.LogInformation("Have no PlanSemester...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {planSemester.TotalCount} PlanSemester from database...");
                return planSemester;
            }

        }

        public PlanSemester GetPlanSemesterByPlanSemesterId(int Id)
        {
            _log.LogInformation($"Search PlanSemester {Id}...");
            var planSemester = _planSemesterRepository.GetPlanSemesterByPlanSemesterId(Id);
            if (planSemester is null)
            {
                _log.LogInformation($"Can not found PlanSemester {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success PlanSemester {Id}...");
                return planSemester;
            }
        }

        public void RemovePlanSemester(PlanSemester planSemester)
        {
            _log.LogInformation($"Remove PlanSemester {planSemester.PlanSemesterId}...");
            _planSemesterRepository.Remove(planSemester);
            try
            {
                if (_planSemesterRepository.SaveChanges())
                {
                    _log.LogInformation($"Remove PlanSemester {planSemester.PlanSemesterId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove PlanSemester {planSemester.PlanSemesterId} fail with error: {e.Message}");
            }
        }

        public void UpdatePlanSemester(PlanSemester planSemester)
        {
            _log.LogInformation($"Update PlanSemester {planSemester.PlanSemesterId}...");
            _planSemesterRepository.Update(planSemester);
            try
            {
                if (_planSemesterRepository.SaveChanges())
                {
                    _log.LogInformation($"Update PlanSemester {planSemester.PlanSemesterId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update PlanSemester {planSemester.PlanSemesterId} fail with error: {e.Message}");
            }
        }

    }
}
