using AutoMapper;
using FTask.Api.Dtos.MajorDtos;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class MajorProfile : Profile
    {
        public MajorProfile()
        {
            // Mapper from Source --> Target
            CreateMap<Major, MajorReadDto>();
            CreateMap<Major, MajorReadDetailDto>();
            CreateMap<MajorAddDto, Major>();
            CreateMap<MajorUpdateDto, Major>();
            CreateMap<Major, MajorUpdateDto>();
        }
    }
}
