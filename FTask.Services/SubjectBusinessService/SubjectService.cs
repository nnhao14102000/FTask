using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.SubjectBusinessService
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILogger<SubjectService> _log;

        public SubjectService(ISubjectRepository subjectRepository, ILogger<SubjectService> log)
        {
            _subjectRepository = subjectRepository;
            _log = log;
        }

        public void AddSubject(Subject subject)
        {
            _log.LogInformation($"Add Subject {subject.SubjectName} into database...");
            _subjectRepository.Add(subject);
            try
            {
                if (_subjectRepository.SaveChanges())
                {
                    _log.LogInformation($"Add Subject {subject.SubjectName} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"Add Subject {subject.SubjectName} fail with error: {e.Message}");
            }
        }

        public PagedList<Subject> GetAllSubjects(SubjectParameters subjectParameters)
        {
            var subject = _subjectRepository.GetSubjects(subjectParameters);
            if (subject is null)
            {
                _log.LogInformation("Have no Subject...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {subject.TotalCount} subjects from database...");
                return subject;
            }

        }

        public Subject GetSubjectBySubjectId(string Id)
        {
            _log.LogInformation($"Search Subject {Id}...");
            var subject = _subjectRepository.GetSubjectBySubjecId(Id);
            if (subject is null)
            {
                _log.LogInformation($"Can not found Subject {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success Subject {Id}...");
                return subject;
            }
        }

        public Subject GetSubjectInDetailBySubjectId(string Id)
        {
            _log.LogInformation($"Search Subject {Id}...");
            var subject = _subjectRepository.GetSubjectInDetailBySubjecId(Id);
            if (subject is null)
            {
                _log.LogInformation($"Can not found Subject {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success Subject {Id}...");
                return subject;
            }
        }

        public void RemoveSubject(Subject subject)
        {
            _log.LogInformation($"Remove Subject {subject.SubjectId}...");
            _subjectRepository.Remove(subject);
            try
            {
                if (_subjectRepository.SaveChanges())
                {
                    _log.LogInformation($"Remove Subject {subject.SubjectId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove Subject {subject.SubjectId} fail with error: {e.Message}");
            }
        }

        public void UpdateSubject(Subject subject)
        {
            _log.LogInformation($"Update Subject {subject.SubjectId}...");
            _subjectRepository.Update(subject);
            try
            {
                if (_subjectRepository.SaveChanges())
                {
                    _log.LogInformation($"Update Subject {subject.SubjectId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update Subject {subject.SubjectId} fail with error: {e.Message}");
            }
        }

    }
}
