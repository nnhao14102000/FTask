using AutoMapper;
using FTask.Api.Dtos.MajorViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class MajorProfile : Profile
    {
        public MajorProfile()
        {
            // Mapper from Source --> Target
            CreateMap<Major, MajorReadViewModel>();
            CreateMap<Major, MajorReadDetailViewModel>();
            CreateMap<MajorAddViewModel, Major>();
            CreateMap<MajorUpdateViewModel, Major>();
            CreateMap<Major, MajorUpdateViewModel>();
        }
    }
}
