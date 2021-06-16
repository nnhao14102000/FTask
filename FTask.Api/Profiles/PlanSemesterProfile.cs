using AutoMapper;
using FTask.Api.ViewModels.PlanSemesterViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// PlanSemester mapping profile
    /// </summary>
    public class PlanSemesterProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public PlanSemesterProfile()
        {
            CreateMap<PlanSemester, PlanSemesterReadViewModel>();
            CreateMap<PlanSemester, PSReadDetailViewModel>();
            CreateMap<PlanSemesterAddViewModel, PlanSemester>();
            CreateMap<PlanSemesterUpdateViewModel, PlanSemester>();
            CreateMap<PlanSemester, PlanSemesterUpdateViewModel>();

        }
    }
}
