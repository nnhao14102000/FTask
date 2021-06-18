using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.TaskBusinessService
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<TaskService> _log;

        public TaskService(ITaskRepository TaskRepository, ILogger<TaskService> log)
        {
            _taskRepository = TaskRepository;
            _log = log;
        }

        public void AddTask(Task task)
        {
            _log.LogInformation($"Add Task {task.TaskId} into database...");
            _taskRepository.Add(task);
            try
            {
                if (_taskRepository.SaveChanges())
                {
                    _log.LogInformation($"Add Task {task.TaskId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"Add Task {task.TaskId} fail with error: {e.Message}");
            }
        }

        public PagedList<Task> GetAllTasks(TaskParameters taskPrameters)
        {
            var task = _taskRepository.GetTasks(taskPrameters);
            if (task is null)
            {
                _log.LogInformation("Have no Task...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {task.TotalCount} Task from database...");
                return task;
            }

        }

        public Task GetTaskByTaskId(int Id)
        {
            _log.LogInformation($"Search Task {Id}...");
            var task = _taskRepository.GetTaskByTaskId(Id);
            if (task is null)
            {
                _log.LogInformation($"Can not found Task {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success Task {Id}...");
                return task;
            }
        }

        public void RemoveTask(Task task)
        {
            _log.LogInformation($"Remove Task {task.TaskId}...");
            _taskRepository.Remove(task);
            try
            {
                if (_taskRepository.SaveChanges())
                {
                    _log.LogInformation($"Remove Task {task.TaskId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove Task {task.TaskId} fail with error: {e.Message}");
            }
        }

        public void UpdateTask(Task task)
        {
            _log.LogInformation($"Update Task {task.TaskId}...");
            _taskRepository.Update(task);
            try
            {
                if (_taskRepository.SaveChanges())
                {
                    _log.LogInformation($"Update Task {task.TaskId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update Task {task.TaskId} fail with error: {e.Message}");
            }
        }

    }
}
