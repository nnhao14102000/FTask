using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ISemesterRepository : IGenericRepository<Semester>
    {
        PagedList<Semester> GetSemesters(SemesterParameters semesterParameters);
        Semester GetSemesterBySemesterId(string id);
    }
}
