﻿using AutoMapper;
using FTask.Api.ViewModels.SubjectGroupViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.SubjectGroupBusinessService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// Subject group controller
    /// </summary>
    [ApiController]
    [Route("api/subject-groups")]
    [ApiVersion("1.0")]
    public class SubjectGroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubjectGroupService _subjectGroupService;

        /// <summary>
        /// Constructor DI AutoMapper and Subject group service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="SubjectGroupService"></param>
        public SubjectGroupController(IMapper mapper, ISubjectGroupService SubjectGroupService)
        {
            _mapper = mapper;
            _subjectGroupService = SubjectGroupService;
        }

        /// <summary>
        /// Get all Subject group
        /// </summary>
        /// <param name="subjectGroupParameter"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<SubjectGroupReadViewModel>> GetAllSubjectGroups([FromQuery] SubjectGroupParameters subjectGroupParameter)
        {
            var subjectGroup = _subjectGroupService.GetAllSubjectGroups(subjectGroupParameter);

            var metaData = new
            {
                subjectGroup.TotalCount,
                subjectGroup.PageSize,
                subjectGroup.CurrentPage,
                subjectGroup.HasNext,
                subjectGroup.HasPrevious
            };
            Response.Headers.Add("SubjectGroup-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<SubjectGroupReadViewModel>>(subjectGroup));
        } 

        /// <summary>
        /// Get Subject group by ID and it Relevant subject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSubjectGroupBySubjectGroupId")]
        public ActionResult<SubjectGroupReadDetailViewModel> GetSubjectGroupBySubjectGroupId(int id)
        {
            var subjectGroup = _subjectGroupService.GetSubjectGroupBySubjectGroupId(id);
            if (subjectGroup is not null)
            {
                return Ok(_mapper.Map<SubjectGroupReadDetailViewModel>(subjectGroup));
            }
            return NotFound();
        }

        /// <summary>
        /// Add a subject group into database
        /// </summary>
        /// <param name="subjectGroup"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SubjectGroupReadViewModel> AddSubjectGroup(SubjectGroupAddViewModel subjectGroup)
        {
            var subjectGroupModel = _mapper.Map<SubjectGroup>(subjectGroup);
            _subjectGroupService.AddSubjectGroup(subjectGroupModel);
            var subjectGroupReadModel = _mapper.Map<SubjectGroupReadViewModel>(subjectGroupModel);

            return CreatedAtRoute(nameof(GetSubjectGroupBySubjectGroupId), new { id = subjectGroupReadModel.SubjectGroupId }, subjectGroupReadModel);
        }

        /// <summary>
        /// Update Subject group
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectGroup"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateSubjectGroup (int id, SubjectGroupUpdateViewModel subjectGroup)
        {
            var subjectGroupModel = _subjectGroupService.GetSubjectGroupBySubjectGroupId(id);
            if (subjectGroupModel is null)
            {
                return NotFound();
            }
            _mapper.Map(subjectGroup, subjectGroupModel);
            _subjectGroupService.UpdateSubjectGroup(subjectGroupModel);
            return NoContent();
        }

        /// <summary>
        /// Update Subject group by PATCH method...Allow update a single attribute
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult PartialSubjectGroupUpdate(int id, JsonPatchDocument<SubjectGroupUpdateViewModel> patchDoc)
        {
            var subjectGroupModel = _subjectGroupService.GetSubjectGroupBySubjectGroupId(id);
            if (subjectGroupModel is null)
            {
                return NotFound();
            }
            var subjectGroupToPatch = _mapper.Map<SubjectGroupUpdateViewModel>(subjectGroupModel);
            patchDoc.ApplyTo(subjectGroupToPatch, ModelState);
            if (!TryValidateModel(subjectGroupToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(subjectGroupToPatch, subjectGroupModel);
            _subjectGroupService.UpdateSubjectGroup(subjectGroupModel);
            return NoContent();
        }

        /// <summary>
        /// Remove a Subject group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult RemoveSubjectGroup(int id)
        {
            var subjectGroupModel = _subjectGroupService.GetSubjectGroupBySubjectGroupId(id);
            if (subjectGroupModel is null)
            {
                return NotFound();
            }
            _subjectGroupService.RemoveSubjectGroup(subjectGroupModel);
            return NoContent();
        }
    }
}
