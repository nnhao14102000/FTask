﻿using AutoMapper;
using FTask.Api.ViewModels.MajorViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.MajorBusinessService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    /// <summary>
    /// Major Controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/majors")]
    [ApiVersion("1.0")]
    public class MajorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMajorService _majorService;
        /// <summary>
        /// Constructor DI AutoMapper and MajorService
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="MajorService"></param>
        public MajorController(IMapper mapper, IMajorService MajorService)
        {
            _mapper = mapper;
            _majorService = MajorService;
        }

        /// <summary>
        /// Get all majors in database
        /// </summary>
        /// <param name="majorParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<MajorReadViewModel>> GetAllMajors([FromQuery] MajorParameters majorParameter)
        {
            var majors = _majorService.GetAllMajors(majorParameter);

            var metaData = new
            {
                majors.TotalCount,
                majors.PageSize,
                majors.CurrentPage,
                majors.HasNext,
                majors.HasPrevious
            };
            Response.Headers.Add("Major-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<MajorReadViewModel>>(majors));
        }

        /// <summary>
        /// Get major and relevant student in this major by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetMajorByMajorId")]
        [MapToApiVersion("1.0")]
        public ActionResult<MajorReadDetailViewModel> GetMajorByMajorId(string id)
        {
            var major = _majorService.GetMajorByMajorId(id);
            if (major is not null)
            {
                return Ok(_mapper.Map<MajorReadDetailViewModel>(major));
            }
            return NotFound();
        }

        /// <summary>
        /// Add new major into databas
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<MajorReadViewModel> AddMajor(MajorAddViewModel major)
        {
            var isExisted = _majorService.GetMajorByMajorId(major.MajorId);
            if (isExisted is not null)
            {
                return BadRequest("Major Id is existed....");
            }

            var majorModel = _mapper.Map<Major>(major);
            _majorService.AddMajor(majorModel);
            var majorReadModel = _mapper.Map<MajorReadViewModel>(majorModel);

            return CreatedAtRoute(nameof(GetMajorByMajorId), new { id = majorReadModel.MajorId }, majorReadModel);
        }

        /// <summary>
        /// Update infomation of a major
        /// </summary>
        /// <param name="id"></param>
        /// <param name="major"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdateMajor(string id, MajorUpdateViewModel major)
        {
            var majorModel = _majorService.GetMajorByMajorId(id);
            if (majorModel is null)
            {
                return NotFound();
            }
            _mapper.Map(major, majorModel);
            _majorService.UpdateMajor(majorModel);
            return NoContent();
        }

        /// <summary>
        /// Update major by PATCH method...Allow update a single attribute
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialMajorUpdate(string id, JsonPatchDocument<MajorUpdateViewModel> patchDoc)
        {
            var majorModel = _majorService.GetMajorByMajorId(id);
            if (majorModel is null)
            {
                return NotFound();
            }
            var majorToPatch = _mapper.Map<MajorUpdateViewModel>(majorModel);
            patchDoc.ApplyTo(majorToPatch, ModelState);
            if (!TryValidateModel(majorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(majorToPatch, majorModel);
            _majorService.UpdateMajor(majorModel);
            return NoContent();
        }

        /// <summary>
        /// Remove a major
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult RemoveMajor(string id)
        {
            var majorModel = _majorService.GetMajorByMajorId(id);
            if (majorModel is null)
            {
                return NotFound();
            }
            _majorService.RemoveMajor(majorModel);
            return NoContent();
        }

    }
}
