using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Database.Repositories.IRepository
{
    public interface ITaskCategoryRepository : IGenericRepository<TaskCategory>
    {
        PagedList<TaskCategory> GetTaskCategorys(TaskCategoryParameters taskCategoryParameters);
        TaskCategory GetTaskCategoryByTaskCategoryId(int id);
    }
}
