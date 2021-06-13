using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Services.TaskCategoryBusinessService
{
    public interface ITaskCategoryService
    {
        PagedList<TaskCategory> GetAllTaskCategorys(TaskCategoryParameters taskCategoryPrameters);
        TaskCategory GetTaskCategoryByTaskCategoryId(int Id);
        void AddTaskCategory(TaskCategory taskCategory);
        void UpdateTaskCategory(TaskCategory taskCategory);
        void RemoveTaskCategory(TaskCategory taskCategory);
    }
}
