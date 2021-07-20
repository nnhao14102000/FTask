using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.SemesterBusinessService
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly ILogger<SemesterService> _log;

        public SemesterService(ISemesterRepository semesterRepository, ILogger<SemesterService> log)
        {
            _semesterRepository = semesterRepository;
            _log = log;
        }

        public void AddSemester(Semester semester)
        {
            _log.LogInformation($"Add Semester {semester.SemesterId} into database...");
            _semesterRepository.Add(semester);
            try
            {
                if (_semesterRepository.SaveChanges(semester))
                {
                    _log.LogInformation($"Add Semester {semester.SemesterId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Add Semester {semester.SemesterId} fail with error: {e.Message}");
            }
        }

        public PagedList<Semester> GetAllSemesters(SemesterParameters semesterParameters)
        {
            var semesters = _semesterRepository.GetSemesters(semesterParameters);
            if (semesters is null)
            {
                _log.LogInformation("Have no semesters...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {semesters.TotalCount} semesters from database...");
                return semesters;
            }
        }

        public Semester GetSemesterBySemesterId(string id)
        {
            _log.LogInformation($"Search semester {id}...");
            var semester = _semesterRepository.GetSemesterBySemesterId(id);
            if (semester is null)
            {
                _log.LogInformation($"Can not found semester {id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success semester {id}...");
                return semester;
            }
        }

        public void RemoveSemester(Semester semester)
        {
            _log.LogInformation($"Remove semester {semester.SemesterId}...");
            _semesterRepository.Remove(semester);
            try
            {
                if (_semesterRepository.SaveChanges(semester))
                {
                    _log.LogInformation($"Remove semester {semester.SemesterId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove semester {semester.SemesterId} fail with error: {e.Message}");
            }
        }

        public void UpdateSemester(Semester semester)
        {
            _log.LogInformation($"Update semester {semester.SemesterId}...");
            _semesterRepository.Update(semester);
            try
            {
                if (_semesterRepository.SaveChanges(semester))
                {
                    _log.LogInformation($"Update semester {semester.SemesterId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update semester {semester.SemesterId} fail with error: {e.Message}");
            }
        }
    }
}
