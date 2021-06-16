using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Services.PlanSemesterBusinessService
{
    public interface IPlanSemesterService
    {
        PagedList<PlanSemester> GetAllPlanSemesters(PlanSemesterParameters planSemesterPrameters);
        PlanSemester GetPlanSemesterByPlanSemesterId(int Id);
        void AddPlanSemester(PlanSemester planSemester);
        void UpdatePlanSemester(PlanSemester planSemester);
        void RemovePlanSemester(PlanSemester planSemester);
    }
}
