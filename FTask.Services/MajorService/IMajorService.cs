using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Services.MajorService
{
    public interface IMajorService
    {
        PagedList<Major> GetAllMajors(MajorParameters majorParameters);
        Major GetMajorByMajorId(string id);
        void AddMajor(Major major);
        void UpdateMajor(Major major);
        void RemoveMajor(Major major);
    }
}
