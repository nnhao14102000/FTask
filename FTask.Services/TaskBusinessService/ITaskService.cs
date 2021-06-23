using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Services.TaskBusinessService
{
    public interface ITaskService
    {
        PagedList<Task> GetAllTasks(TaskParameters taskPrameters);
        Task GetTaskByTaskId(int id);
        void AddTask(Task task);
        void UpdateTask(Task task);
        void RemoveTask(Task task);
    }
}
