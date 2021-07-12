using AutoMapper;
using FTask.Api.ViewModels.PlanTopicViewModels;
using FTask.Database.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Plan topic mapper profile
    /// </summary>
    public class PlanTopicProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
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
