using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ITaskCategoryRepository : IGenericRepository<TaskCategory>
    {
        PagedList<TaskCategory> GetTaskCategorys(TaskCategoryParameters taskCategoryParameters);
        TaskCategory GetTaskCategoryByTaskCategoryId(int id);
    }
}
