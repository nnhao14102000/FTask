using FTask.Database.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Database.Repositories.IRepository
{
    public interface ISemesterRepository : IGenericRepository<Semester>
    {
        PagedList<Semester> GetSemesters(SemesterParameters semesterParameters);
        Semester GetSemesterBySemesterId(string id);
    }
}
