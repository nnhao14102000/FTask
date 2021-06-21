using AutoMapper;
using FTask.Api.ViewModels.SubjectViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.SubjectBusinessService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    /// <summary>
    /// Subject controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/subjects")]
    [ApiVersion("1.0")]
    public class SubjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;

        /// <summary>
        /// Constructor DI AutoMapper and subject service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="subjectService"></param>
        public SubjectController(IMapper mapper, ISubjectService subjectService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
        }

        /// <summary>
        /// API version 1 | Get all subjects, allow search by name 
        /// </summary>
        /// <param name="subjectParameters"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
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
            Response.Headers.Add("Subject-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<SubjectReadViewModel>>(subject));
        }

        /// <summary>
        /// API version 1 | Get subject by Subject ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSubjectInDetailBySubjectId")]
        [MapToApiVersion("1.0")]
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
        /// API version 1 | Add a new subject 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
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

            return CreatedAtRoute(nameof(GetSubjectInDetailBySubjectId), new { id = SubjectReadModel.SubjectId }, SubjectReadModel);
        }

        /// <summary>
        /// API version 1 | Update subject 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdateSubject(string id, SubjectUpdateViewModel subject)
        {
            var subjectModel = _subjectService.GetSubjectBySubjectId(id);
            if (subjectModel is null)
            {
                return NotFound();
            }
            _mapper.Map(subject, subjectModel);
            _subjectService.UpdateSubject(subjectModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Update subject by PATCH method...Allow update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialSubjectUpdate(string id, JsonPatchDocument<SubjectUpdateViewModel> patchDoc)
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
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Remove subject 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult RemoveSubject(string id)
        {
            var subjectModel = _subjectService.GetSubjectBySubjectId(id);
            if (subjectModel is null)
            {
                return NotFound();
            }
            _subjectService.RemoveSubject(subjectModel);
            return NoContent();
        }

    }
}
