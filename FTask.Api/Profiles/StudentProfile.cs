using AutoMapper;
using FTask.Api.ViewModels.MajorViewModels;
using FTask.Api.ViewModels.StudentViewModels;
using FTask.Data.Models;

namespace FTaskAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // Mapper from Source --> Target
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
