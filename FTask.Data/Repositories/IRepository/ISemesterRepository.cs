using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ISemesterRepository : IGenericRepository <Semester>
    {
        PagedList<Semester> GetSemesters(SemesterParameters semesterParameters);
        Semester GetSemesterBySemesterId(string id);
    }
}
