using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Services.SemesterBusinessService
{
    public interface ISemesterService
    {
        PagedList<Semester> GetAllSemesters(SemesterParameters semesterParameters);
        Semester GetSemesterBySemesterId(string id);
        void AddSemester(Semester semester);
        void UpdateSemester(Semester semester);
        void RemoveSemester(Semester semester);
    }
}
