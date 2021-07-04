using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Database.Repositories.IRepository
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        PagedList<Task> GetTasks(TaskParameters taskParameters);
        Task GetTaskByTaskId(int id);
    }
}
