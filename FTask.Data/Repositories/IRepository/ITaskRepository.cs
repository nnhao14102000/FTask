using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        PagedList<Task> GetTasks(TaskParameters taskParameters);
        Task GetTaskByTaskId(int id);
    }
}
