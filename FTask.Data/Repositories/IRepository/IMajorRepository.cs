using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface IMajorRepository : IGenericRepository<Major>
    {
        PagedList<Major> GetMajors(MajorParameters majorParameters);
        Major GetMajorByMajorId(string id);
        Major GetMajorInDetailByMajorId(string id);
    }
}
