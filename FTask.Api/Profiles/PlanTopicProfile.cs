using AutoMapper;
using FTask.Api.ViewModels.PlanTopicViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class PlanTopicProfile : Profile
    {
        public PlanTopicProfile()
        {
            CreateMap<PlanTopic, PlanTopicReadViewModel>();
            CreateMap<PlanTopic, PlanTopicReadDetailViewModel>();
            CreateMap<PlanTopicAddViewModel, PlanTopic>();
            CreateMap<PlanTopicUpdateViewModel, PlanTopic>();
            CreateMap<PlanTopic, PlanTopicUpdateViewModel>();

        }
    }
}
