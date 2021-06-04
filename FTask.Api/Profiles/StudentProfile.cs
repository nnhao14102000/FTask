using AutoMapper;
using FTask.Api.Dtos.StudentDtos;
using FTask.Data.Models;

namespace FTaskAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // Mapper from Source --> Target
            CreateMap<Student, StudentReadDto>();
            CreateMap<Student, StudentReadDetailDto>();
            CreateMap<StudentAddDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentUpdateDto>();
        }
    }
}
