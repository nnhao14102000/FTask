using AutoMapper;
using FTask.Api.ViewModels.SubjectViewModels;
using FTask.Api.ViewModels.TopicViewModels;
using FTask.Database.Models;

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

            // Config for topics in subject
            CreateMap<Topic, TopicsInSubjectReadViewModel>();
        }
    }
}
