using AutoMapper;
using FTask.Api.Dtos.SubjectGroupViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.SubjectGroupService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    [ApiController]
    [Route("api/subject-groups")]
    [ApiVersion("1.0")]
    public class SubjectGroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubjectGroupService _subjectGroupService;

        public SubjectGroupController(IMapper mapper, ISubjectGroupService SubjectGroupService)
        {
            _mapper = mapper;
            _subjectGroupService = SubjectGroupService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubjectGroupReadViewModel>> GetAllSubjectGroups([FromQuery] SubjectGroupParametes subjectGroupParameter)
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

        [HttpPost]
        public ActionResult<SubjectGroupReadViewModel> AddSubjectGroup(SubjectGroupAddViewModel subjectGroup)
        {
            var subjectGroupModel = _mapper.Map<SubjectGroup>(subjectGroup);
            _subjectGroupService.AddSubjectGroup(subjectGroupModel);
            var subjectGroupReadModel = _mapper.Map<SubjectGroupReadViewModel>(subjectGroupModel);

            return CreatedAtRoute(nameof(GetSubjectGroupBySubjectGroupId), new { id = subjectGroupReadModel.SubjectGroupId }, subjectGroupReadModel);
        }

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
