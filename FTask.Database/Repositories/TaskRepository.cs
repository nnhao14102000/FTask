using FTask.Database.Models;
using FTask.Database.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
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
            return FindByCondition(x => x.TaskId == id).FirstOrDefault();
        }

        public PagedList<Task> GetTasks(TaskParameters taskParameters)
        {
            var tasks = FindAll();
            GetByPlanTopicId(ref tasks, taskParameters.PlanTopicId);

            return PagedList<Task>
                .ToPagedList(tasks, taskParameters.PageNumber, taskParameters.PageSize);
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
    }
}
