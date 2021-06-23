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
            return PagedList<Task>
                .ToPagedList(FindAll(), taskParameters.PageNumber, taskParameters.PageSize);
        }
    }
}
