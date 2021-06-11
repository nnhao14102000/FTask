using AutoMapper;
using FTask.Api.ViewModels.MajorViewModels;
using FTask.Api.ViewModels.StudentViewModels;
using FTask.Data.Models;

namespace FTaskAPI.Profiles
{
    /// <summary>
    /// Student mapping profile
    /// </summary>
    public class StudentProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public StudentProfile()
        {
            CreateMap<Student, StudentReadViewModel>();
            CreateMap<Student, StudentReadDetailViewModel>();            
            CreateMap<StudentAddViewModel, Student>();
            CreateMap<StudentUpdateViewModel, Student>();
            CreateMap<Student, StudentUpdateViewModel>();

            // Mapping for Student get in Major
            CreateMap<Student, StudentOfMajorViewModel>();
        }
    }
}
