using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using System;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class TaskCategoryRepository : GenericRepository<TaskCategory>, ITaskCategoryRepository 
    {
        private FTaskContext context { get; set; }

        public TaskCategoryRepository(FTaskContext context): base(context)
        {
            this.context = context;
        }

        public TaskCategory GetTaskCategoryByTaskCategoryId(int id)
        {
            return FindByCondition(tc => tc.TaskCategoryId.Equals(id)).FirstOrDefault();
        }

        public PagedList<TaskCategory> GetTaskCategorys(TaskCategoryParameters taskCategoryParameters)
        {
            var taskCategory = FindAll();
            SearchByName(ref taskCategory, taskCategoryParameters.TaskType);

            return PagedList<TaskCategory>
                .ToPagedList(taskCategory.OrderBy(tc => tc.TaskType),
                 taskCategoryParameters.PageNumber, taskCategoryParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<TaskCategory> taskCategory, string taskType)
        {
            if (!taskCategory.Any() || string.IsNullOrWhiteSpace(taskType))
            {
                return;
            }
            taskCategory = taskCategory
                .Where(s => s.TaskType.ToLower()
                .Contains(taskType.Trim().ToLower()));
        }
    }
}
