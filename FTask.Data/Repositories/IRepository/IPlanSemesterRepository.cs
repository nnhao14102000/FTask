using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface IPlanSemesterRepository : IGenericRepository<PlanSemester>
    {
        PagedList<PlanSemester> GetPlanSemesters(PlanSemesterParameters planSemesterParameters);
        PlanSemester GetPlanSemesterByPlanSemesterId(int id);
    }
}
