﻿using AutoMapper;
using FTask.Api.ViewModels.PlanSubjectViewModels;
using FTask.Data.Models;

namespace FTask.Api.Profiles
{
    /// <summary>
    /// Plan Subject mapper profile
    /// </summary>
    public class PlanSubjectProfile :Profile
    {
        /// <summary>
        /// Constructor Mapper from Source --> Target
        /// </summary>
        public PlanSubjectProfile()
        {
            CreateMap<PlanSubject, PlanSubjectReadViewModel>();
            CreateMap<PlanSubject, PlanSubjectReadDetailViewModel>();
            CreateMap<PlanSubjectAddViewModel, PlanSubject>();
            CreateMap<PlanSubjectUpdateViewModel, PlanSubject>();
            CreateMap<PlanSubject, PlanSubjectUpdateViewModel>();

        }
    }
}
