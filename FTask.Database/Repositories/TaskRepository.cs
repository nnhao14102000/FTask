using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FTask.Database.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        private FTaskContext context;
        public TaskRepository(FTaskContext context) : base(context)
        {
            this.context = context;
        }
        public Task GetTaskByTaskId(int id)
        {
            var task = FindByCondition(x => x.TaskId == id).FirstOrDefault();
            context.Entry(task)
                .Reference(x => x.TaskCategory)
                .Query()
                .Load();

            return task;
        }

        public PagedList<Task> GetTasks(TaskParameters taskParameters)
        {
            var tasks = FindAll();
            SearchByValue(ref tasks, taskParameters.TaskSearchValue);
            GetByPlanTopicId(ref tasks, taskParameters.PlanTopicId);
            SortHigherPriority(ref tasks);
            SortLatestTask(ref tasks);
            foreach (var item in tasks)
            {
                context.Entry(item)
                    .Reference(x => x.TaskCategory)
                    .Query()
                    .Load();
            }
            return PagedList<Task>
                .ToPagedList(tasks, taskParameters.PageNumber, taskParameters.PageSize);
        }

        private void SortHigherPriority(ref IQueryable<Task> tasks)
        {
            if (!tasks.Any())
            {
                return;
            }            
            tasks = tasks
                .OrderByDescending(x => x.Priority);
        }

        private void GetByPlanTopicId(ref IQueryable<Task> tasks, int planTopicId)
        {
            if (!tasks.Any() || planTopicId == 0)
            {
                return;
            }
            tasks = tasks
                .Where(x => x.PlanTopicId == planTopicId);
        }

        private void SearchByValue(ref IQueryable<Task> tasks, string searchValue)
        {
            if (!tasks.Any() || string.IsNullOrWhiteSpace(searchValue))
            {
                return;
            }
            tasks = tasks
                .Where(x => x.TaskDescription.ToLower()
                                .Contains(searchValue.Trim().ToLower()));
        }

        private void SortLatestTask(ref IQueryable<Task> tasks)
        {
            if (!tasks.Any())
            {
                return;
            }            
            tasks = tasks
                .OrderByDescending(x => x.CreateDate);
        }
    }
}
