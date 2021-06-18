using AutoMapper;
using FTask.Api.ViewModels.TaskViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskReadViewModel>();
            CreateMap<TaskAddViewModel, Task>();
            CreateMap<TaskUpdateViewModel, Task>();
            CreateMap<Task, TaskUpdateViewModel>();
        }
    }
}
