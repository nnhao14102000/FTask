using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Services.MajorBusinessService
{
    public interface IMajorService
    {
        PagedList<Major> GetAllMajors(MajorParameters majorParameters);
        Major GetMajorByMajorId(string id);
        Major GetMajorInDetailByMajorId(string id);
        void AddMajor(Major major);
        void UpdateMajor(Major major);
        void RemoveMajor(Major major);
    }
}
