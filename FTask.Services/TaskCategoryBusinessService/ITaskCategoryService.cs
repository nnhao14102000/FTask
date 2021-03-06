using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Services.TaskCategoryBusinessService
{
    public interface ITaskCategoryService
    {
        PagedList<TaskCategory> GetAllTaskCategories(TaskCategoryParameters taskCategoryPrameters);
        TaskCategory GetTaskCategoryByTaskCategoryId(int Id);
        void AddTaskCategory(TaskCategory taskCategory);
        void UpdateTaskCategory(TaskCategory taskCategory);
        void RemoveTaskCategory(TaskCategory taskCategory);
    }
}
