using AutoMapper;
using FTask.Api.ViewModels.SubjectViewModels;
using FTask.AuthDatabase.Models;
using FTask.Cache;
using FTask.Database.Models;
using FTask.Services.SubjectBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    /// <summary>
    /// API version 1.0 | Subject controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/subjects")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class SubjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;

        /// <summary>
        /// Constructor inject auto mapper and subject services
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="subjectService"></param>
        public SubjectController(IMapper mapper, 
            ISubjectService subjectService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
        }

        /// <summary>
        /// API version 1.0 | Roles: admin, user | Get all subjects | Support search by subject name, subject Id, filter by subject group Id
        /// </summary>
        /// <param name="subjectParameters"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [Cached(600)]
        public ActionResult<IEnumerable<SubjectReadViewModel>> GetAllSubjects([FromQuery] SubjectParameters subjectParameters)
        {
            var subject = _subjectService.GetAllSubjects(subjectParameters);

            var metaData = new
            {
                subject.TotalCount,
                subject.PageSize,
                subject.CurrentPage,
                subject.HasNext,
                subject.HasPrevious
            };
            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<SubjectReadViewModel>>(subject));
        }

        /// <summary>
        /// API version 1.0 | Roles: admin, user | Get subject by subject Id and it's relevant topics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSubjectInDetailBySubjectId")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [Cached(600)]
        public ActionResult<SubjectReadDetailViewModel> GetSubjectInDetailBySubjectId(string id)
        {
            var isExisted = _subjectService.GetSubjectBySubjectId(id);
            if (isExisted is null)
            {
                return NotFound();
            }
            var subject = _subjectService.GetSubjectInDetailBySubjectId(id);
            return Ok(_mapper.Map<SubjectReadDetailViewModel>(subject));

        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Add a new subject 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<SubjectReadViewModel> AddSubject(SubjectAddViewModel subject)
        {
            var isExisted = _subjectService.GetSubjectBySubjectId(subject.SubjectId);
            if (isExisted is not null)
            {
                return BadRequest("Subject Id is existed....");
            }

            var subjectModel = _mapper.Map<Subject>(subject);
            _subjectService.AddSubject(subjectModel);
            var SubjectReadModel = _mapper.Map<SubjectReadViewModel>(subjectModel);

            return CreatedAtRoute(
                nameof(GetSubjectInDetailBySubjectId), 
                new { id = SubjectReadModel.SubjectId }, SubjectReadModel
            );
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Update subject 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateSubject(string id, SubjectUpdateViewModel subject)
        {
            var subjectModel = _subjectService.GetSubjectBySubjectId(id);
            if (subjectModel is null)
            {
                return NotFound();
            }
            _mapper.Map(subject, subjectModel);
            _subjectService.UpdateSubject(subjectModel);
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
        public ActionResult PartialSubjectUpdate(string id, 
            JsonPatchDocument<SubjectUpdateViewModel> patchDoc)
        {
            var subjectModel = _subjectService.GetSubjectBySubjectId(id);
            if (subjectModel is null)
            {
                return NotFound();
            }
            var SubjectToPatch = _mapper.Map<SubjectUpdateViewModel>(subjectModel);
            patchDoc.ApplyTo(SubjectToPatch, ModelState);
            if (!TryValidateModel(SubjectToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(SubjectToPatch, subjectModel);
            _subjectService.UpdateSubject(subjectModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Remove subject 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult RemoveSubject(string id)
        {
            var subjectModel = _subjectService.GetSubjectBySubjectId(id);
            if (subjectModel is null)
            {
                return NotFound();
            }
            _subjectService.RemoveSubject(subjectModel);
            return Ok("Remove Successfull!");
        }

    }
}
