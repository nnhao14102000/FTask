using AutoMapper;
using FTask.Api.ViewModels.TaskViewModels;
using FTask.Api.ViewModels.TopicViewModels;
using FTask.Database.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Task mapper profile
    /// </summary>
    public class TaskProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public TaskProfile()
        {
            CreateMap<Task, TaskReadViewModel>();
            CreateMap<TaskAddViewModel, Task>();
            CreateMap<TaskUpdateViewModel, Task>();
            CreateMap<Task, TaskUpdateViewModel>();
        }
    }
}
