using AutoMapper;
using FTask.Api.Dtos.StudentViewModels;
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
        }
    }
}
