using AutoMapper;
using FTask.Api.ViewModels.SemesterViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    public class SemesterProfile : Profile
    {
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
