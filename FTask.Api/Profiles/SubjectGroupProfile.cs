using AutoMapper;
using FTask.Api.Dtos.SubjectGroupViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class SubjectGroupProfile : Profile
    {
        public SubjectGroupProfile()
        {
            // Mapper from Source --> Target
            CreateMap<SubjectGroup, SubjectGroupReadViewModel>();
            CreateMap<SubjectGroup, SubjectGroupReadDetailViewModel>();
            CreateMap<SubjectGroupAddViewModel, SubjectGroup>();
            CreateMap<SubjectGroupUpdateViewModel, SubjectGroup>();
            CreateMap<SubjectGroup, SubjectGroupUpdateViewModel>();
        }
    
    }
}
