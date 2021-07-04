using AutoMapper;
using FTask.Api.ViewModels.SubjectGroupViewModels;
using FTask.Api.ViewModels.SubjectViewModels;
using FTask.Database.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Subject mapping profile
    /// </summary>
    public class SubjectProfile : Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectReadViewModel>();
            CreateMap<Subject, SubjectReadDetailViewModel>();
            CreateMap<SubjectAddViewModel, Subject>();
            CreateMap<SubjectUpdateViewModel, Subject>();
            CreateMap<Subject, SubjectUpdateViewModel>();

            // Config for sujects in a subject group
            CreateMap<Subject, SubjectsOfSubjectGroupViewModel>();
        }

    }
}
