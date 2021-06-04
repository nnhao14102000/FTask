using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.MajorService
{
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _majorRepository;
        private readonly ILogger<MajorService> _log;

        public MajorService(IMajorRepository majorRepository, ILogger<MajorService> log)
        {
            _majorRepository = majorRepository;
            _log = log;
        }

        public PagedList<Major> GetAllMajors(MajorParameters majorParameters)
        {
            var majors = _majorRepository.GetMajors(majorParameters);
            if (majors is null)
            {
                _log.LogInformation("Have no majors...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {majors.TotalCount} majors from database...");
                return majors;
            }
        }

        public Major GetMajorByMajorId(string id)
        {
            _log.LogInformation($"Search major {id}...");
            var major = _majorRepository.GetMajorByMajorId(id);
            if (major is null)
            {
                _log.LogInformation($"Can not found major {id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success major {id}...");
                return major;
            }
        }

        public void AddMajor(Major major)
        {
            _log.LogInformation($"Add major {major.MajorId} into database...");
            _majorRepository.Add(major);
            try
            {
                if (_majorRepository.SaveChanges())
                {
                    _log.LogInformation($"Add major {major.MajorId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Add major {major.MajorId} fail with error: {e.Message}");
            }
        }

        public void UpdateMajor(Major major)
        {
            _log.LogInformation($"Update major {major.MajorId}...");
            _majorRepository.Update(major);
            try
            {
                if (_majorRepository.SaveChanges())
                {
                    _log.LogInformation($"Update major {major.MajorId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update major {major.MajorId} fail with error: {e.Message}");
            }
        }

        public void RemoveMajor(Major major)
        {
            _log.LogInformation($"Remove major {major.MajorId}...");
            _majorRepository.Remove(major);
            try
            {
                if (_majorRepository.SaveChanges())
                {
                    _log.LogInformation($"Remove major {major.MajorId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove major {major.MajorId} fail with error: {e.Message}");
            }
        }
                
    }
}
