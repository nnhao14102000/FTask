using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface IPlanSemesterRepository : IGenericRepository<PlanSemester>
    {
        PagedList<PlanSemester> GetPlanSemesters(PlanSemesterParameters planSemesterParameters);
        PlanSemester GetPlanSemesterByPlanSemesterId(int id);
    }
}
