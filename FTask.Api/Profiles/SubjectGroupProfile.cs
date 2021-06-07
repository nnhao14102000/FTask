using AutoMapper;
using FTask.Api.Dtos.SubjectGroupDtos;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class SubjectGroupProfile : Profile
    {
        public SubjectGroupProfile()
        {
            // Mapper from Source --> Target
            CreateMap<SubjectGroup, SubjectGroupReadDTO>();
            CreateMap<SubjectGroup, SubjectGroupReadDetailDTO>();
            CreateMap<SubjectGroupAddDTO, SubjectGroup>();
            CreateMap<SubjectGroupUpdateDTO, SubjectGroup>();
            CreateMap<SubjectGroup, SubjectGroupUpdateDTO>();
        }
    
    }
}
