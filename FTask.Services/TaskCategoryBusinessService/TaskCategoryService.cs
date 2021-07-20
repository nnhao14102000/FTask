using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.TaskCategoryBusinessService
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly ITaskCategoryRepository _taskCategoryRepository;
        private readonly ILogger<TaskCategoryService> _log;

        public TaskCategoryService(ITaskCategoryRepository taskCategoryRepository, ILogger<TaskCategoryService> log)
        {
            _taskCategoryRepository = taskCategoryRepository;
            _log = log;
        }

        public void AddTaskCategory(TaskCategory taskCategory)
        {
            _log.LogInformation($"Add TaskCategory {taskCategory.TaskType} into database...");
            _taskCategoryRepository.Add(taskCategory);
            try
            {
                if (_taskCategoryRepository.SaveChanges(taskCategory))
                {
                    _log.LogInformation($"Add TaskCategory {taskCategory.TaskType} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"Add TaskCategory {taskCategory.TaskType} fail with error: {e.Message}");
            }
        }

        public PagedList<TaskCategory> GetAllTaskCategories(TaskCategoryParameters taskCategoryParameters)
        {
            var taskCategory = _taskCategoryRepository.GetTaskCategories(taskCategoryParameters);
            if (taskCategory is null)
            {
                _log.LogInformation("Have no Task Category...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {taskCategory.TotalCount} Task Category from database...");
                return taskCategory;
            }

        }

        public TaskCategory GetTaskCategoryByTaskCategoryId(int Id)
        {
            _log.LogInformation($"Search Task Category {Id}...");
            var taskCategory = _taskCategoryRepository.GetTaskCategoryByTaskCategoryId(Id);
            if (taskCategory is null)
            {
                _log.LogInformation($"Can not found Task Category {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success Task Category {Id}...");
                return taskCategory;
            }
        }

        public void RemoveTaskCategory(TaskCategory taskCategory)
        {
            _log.LogInformation($"Remove Task Category {taskCategory.TaskCategoryId}...");
            _taskCategoryRepository.Remove(taskCategory);
            try
            {
                if (_taskCategoryRepository.SaveChanges(taskCategory))
                {
                    _log.LogInformation($"Remove Task Category {taskCategory.TaskCategoryId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove Task Category {taskCategory.TaskCategoryId} fail with error: {e.Message}");
            }
        }

        public void UpdateTaskCategory(TaskCategory taskCategory)
        {
            _log.LogInformation($"Update Task Category {taskCategory.TaskCategoryId}...");
            _taskCategoryRepository.Update(taskCategory);
            try
            {
                if (_taskCategoryRepository.SaveChanges(taskCategory))
                {
                    _log.LogInformation($"Update Task Category {taskCategory.TaskCategoryId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update Task Category {taskCategory.TaskCategoryId} fail with error: {e.Message}");
            }
        }

    }
}
