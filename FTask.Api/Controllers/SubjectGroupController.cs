using AutoMapper;
using FTask.Api.ViewModels.SubjectGroupViewModels;
using FTask.AuthDatabase.Models;
using FTask.Database.Models;
using FTask.Services.SubjectGroupBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// API version 1.0 | Subject group controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/subject-groups")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class SubjectGroupController : Controller
    {
        private readonly IMapper _mapper;

        private readonly ISubjectGroupService _subjectGroupService;

        /// <summary>
        /// Constructor inject auto mapper and subject group services
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="SubjectGroupService"></param>
        public SubjectGroupController(IMapper mapper,
            ISubjectGroupService SubjectGroupService)
        {
            _mapper = mapper;
            _subjectGroupService = SubjectGroupService;
        }

        /// <summary>
        /// API version 1.0 | Roles: admin, user | Get all subject groups | Support search by name 
        /// </summary>
        /// <param name="subjectGroupParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        public ActionResult<IEnumerable<SubjectGroupReadViewModel>> GetAllSubjectGroups(
            [FromQuery] SubjectGroupParameters subjectGroupParameter)
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
        /// API version 1.0 | Roles: admin, user | Get subject group by ID and it's relevant subjects
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSubjectGroupBySubjectGroupId")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
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
        /// API version 1.0 | Roles: admin | Add a subject group into database 
        /// </summary>
        /// <param name="subjectGroup"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<SubjectGroupReadViewModel> AddSubjectGroup(
            SubjectGroupAddViewModel subjectGroup)
        {
            var subjectGroupModel = _mapper.Map<SubjectGroup>(subjectGroup);
            _subjectGroupService.AddSubjectGroup(subjectGroupModel);
            var subjectGroupReadModel = _mapper.Map<SubjectGroupReadViewModel>(subjectGroupModel);

            return CreatedAtRoute(
                nameof(GetSubjectGroupBySubjectGroupId),
                new { id = subjectGroupReadModel.SubjectGroupId }, subjectGroupReadModel
            );
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Update subject group 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectGroup"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateSubjectGroup(int id, SubjectGroupUpdateViewModel subjectGroup)
        {
            var subjectGroupModel = _subjectGroupService.GetSubjectGroupBySubjectGroupId(id);
            if (subjectGroupModel is null)
            {
                return NotFound();
            }
            _mapper.Map(subjectGroup, subjectGroupModel);
            _subjectGroupService.UpdateSubjectGroup(subjectGroupModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Update subject | Support update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult PartialSubjectGroupUpdate(int id, 
            JsonPatchDocument<SubjectGroupUpdateViewModel> patchDoc)
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
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Remove a subject group 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult RemoveSubjectGroup(int id)
        {
            var subjectGroupModel = _subjectGroupService.GetSubjectGroupBySubjectGroupId(id);
            if (subjectGroupModel is null)
            {
                return NotFound();
            }
            _subjectGroupService.RemoveSubjectGroup(subjectGroupModel);
            return Ok("Remove Successfull!");
        }
    }
}
