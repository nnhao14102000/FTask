using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.SubjectGroupBusinessService
{
    public class SubjectGroupService : ISubjectGroupService
    {
        private readonly ISubjectGroupRepository _subjectGroupRepository;
        private readonly ILogger<SubjectGroupService> _log;

        public SubjectGroupService(ISubjectGroupRepository subjectGroupRepository, ILogger<SubjectGroupService> log)
        {
            _subjectGroupRepository = subjectGroupRepository;
            _log = log;
        }

        public void AddSubjectGroup(SubjectGroup subjectGroup)
        {
            _log.LogInformation($"Add SubjectGroup {subjectGroup.SubjectGroupName} into database...");
            _subjectGroupRepository.Add(subjectGroup);
            try
            {
                if (_subjectGroupRepository.SaveChanges())
                {
                    _log.LogInformation($"Add SubjectGroup {subjectGroup.SubjectGroupName} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"Add SubjectGroup {subjectGroup.SubjectGroupName} fail with error: {e.Message}");
            }
        }

        public PagedList<SubjectGroup> GetAllSubjectGroups(SubjectGroupParameters subjectGroupPrameters)
        {
            var subjectGroup = _subjectGroupRepository.GetSubjectGroups(subjectGroupPrameters);
            if (subjectGroup is null)
            {
                _log.LogInformation("Have no SubjectGroup...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {subjectGroup.TotalCount} subjectGroup from database...");
                return subjectGroup;
            }

        }

        public SubjectGroup GetSubjectGroupBySubjectGroupId(int Id)
        {
            _log.LogInformation($"Search SubjectGroup {Id}...");
            var subjectGroup = _subjectGroupRepository.GetSubjectGroupBySubjectGroupId(Id);
            if (subjectGroup is null)
            {
                _log.LogInformation($"Can not found subjectGroup {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success subjectGroup {Id}...");
                return subjectGroup;
            }
        }

        public void RemoveSubjectGroup(SubjectGroup subjectGroup)
        {
            _log.LogInformation($"Remove SubjectGroup {subjectGroup.SubjectGroupId}...");
            _subjectGroupRepository.Remove(subjectGroup);
            try
            {
                if (_subjectGroupRepository.SaveChanges())
                {
                    _log.LogInformation($"Remove SubjectGroup {subjectGroup.SubjectGroupId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove SubjectGroup {subjectGroup.SubjectGroupId} fail with error: {e.Message}");
            }
        }

        public void UpdateSubjectGroup(SubjectGroup subjectGroup)
        {
            _log.LogInformation($"Update SubjectGroup {subjectGroup.SubjectGroupId}...");
            _subjectGroupRepository.Update(subjectGroup);
            try
            {
                if (_subjectGroupRepository.SaveChanges())
                {
                    _log.LogInformation($"Update subjectGroup {subjectGroup.SubjectGroupId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update subjectGroup {subjectGroup.SubjectGroupId} fail with error: {e.Message}");
            }
        }

    }
}
