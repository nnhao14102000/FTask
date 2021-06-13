using AutoMapper;
using FTask.Api.ViewModels.TopicViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class TopicProfile : Profile
    {
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
