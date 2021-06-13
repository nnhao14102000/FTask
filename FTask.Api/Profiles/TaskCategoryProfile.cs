using AutoMapper;
using FTask.Api.ViewModels.TaskCategoryViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class TaskCategoryProfile : Profile
    {
        public TaskCategoryProfile()
        {
            CreateMap<TaskCategory, TaskCategoryReadViewModel>();
            CreateMap<TaskCategory, TaskCategoryReadDetailViewModel>();
            CreateMap<TaskCategoryAddViewModel, TaskCategory>();
            CreateMap<TaskCategoryUpdateViewModel, TaskCategory>();
            CreateMap<TaskCategory, TaskCategoryUpdateViewModel>();
        }
    }
}
