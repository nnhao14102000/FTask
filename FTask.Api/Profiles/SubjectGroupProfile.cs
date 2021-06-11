using AutoMapper;
using FTask.Api.ViewModels.SubjectGroupViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Subject group mapping profile
    /// </summary>
    public class SubjectGroupProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public SubjectGroupProfile()
        {
            CreateMap<SubjectGroup, SubjectGroupReadViewModel>();
            CreateMap<SubjectGroup, SubjectGroupReadDetailViewModel>();
            CreateMap<SubjectGroupAddViewModel, SubjectGroup>();
            CreateMap<SubjectGroupUpdateViewModel, SubjectGroup>();
            CreateMap<SubjectGroup, SubjectGroupUpdateViewModel>();
        }
    
    }
}
