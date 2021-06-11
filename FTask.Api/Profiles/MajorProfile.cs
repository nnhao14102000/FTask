using AutoMapper;
using FTask.Api.ViewModels.MajorViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Major mapping profile
    /// </summary>
    public class MajorProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public MajorProfile()
        {
            CreateMap<Major, MajorReadViewModel>();
            CreateMap<Major, MajorReadDetailViewModel>();
            CreateMap<MajorAddViewModel, Major>();
            CreateMap<MajorUpdateViewModel, Major>();
            CreateMap<Major, MajorUpdateViewModel>();

        }
    }
}
