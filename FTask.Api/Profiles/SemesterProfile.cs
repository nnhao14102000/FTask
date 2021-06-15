using AutoMapper;
using FTask.Api.ViewModels.SemesterViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Semester mapping profile
    /// </summary>
    public class SemesterProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public SemesterProfile()
        {            
            CreateMap<Semester, SemesterReadViewModel>();
            CreateMap<Semester, SemesterReadDetailViewModel>();
            CreateMap<SemesterAddViewModel, Semester>();
            CreateMap<SemesterUpdateViewModel, Semester>();
            CreateMap<Semester, SemesterUpdateViewModel>();
        }
    }
}
