using AutoMapper;
using FTask.Api.ViewModels.TaskCategoryViewModels;
using FTask.Database.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Task Category mapping profile
    /// </summary>
    public class TaskCategoryProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
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
