using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        PagedList<Task> GetTasks(TaskParameters taskParameters);
        Task GetTaskByTaskId(int id);
    }
}
