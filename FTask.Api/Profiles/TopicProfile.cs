using AutoMapper;
using FTask.Api.ViewModels.TopicViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Topic mapping profile
    /// </summary>
    public class TopicProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public TopicProfile()
        {
            CreateMap<Topic, TopicReadViewModel>();
            CreateMap<Topic, TopicReadDetailViewModel>();
            CreateMap<TopicAddViewModel, Topic>();
            CreateMap<TopicUpdateViewModel, Topic>();
            CreateMap<Topic, TopicUpdateViewModel>();
        }
    }
}
