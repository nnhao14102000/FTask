using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ITaskCategoryRepository : IGenericRepository<TaskCategory>
    {
        PagedList<TaskCategory> GetTaskCategorys(TaskCategoryParameters taskCategoryParameters);
        TaskCategory GetTaskCategoryByTaskCategoryId(int id);
    }
}
