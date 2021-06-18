using AutoMapper;
using FTask.Api.ViewModels.PlanSubjectViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class PlanSubjectProfile :Profile
    {
        public PlanSubjectProfile()
        {
            CreateMap<PlanSubject, PlanSubjectReadViewModel>();
            CreateMap<PlanSubject, PlanSubjectReadDetailViewModel>();
            CreateMap<PlanSubjectAddViewModel, PlanSubject>();
            CreateMap<PlanSubjectUpdateViewModel, PlanSubject>();
            CreateMap<PlanSubject, PlanSubjectUpdateViewModel>();

        }
    }
}
