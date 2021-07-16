using AutoMapper;
using FTask.Api.ViewModels.SemesterViewModels;
using FTask.AuthDatabase.Models;
using FTask.Cache;
using FTask.Database.Models;
using FTask.Services.SemesterBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    /// <summary>
    /// API version 1.0 | Semester controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/semesters")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class SemesterController : ControllerBase
    {
        private readonly IMapper _mapper;
        
        private readonly ISemesterService _semesterService;

        /// <summary>
        /// Constructor inject auto mapper and semester services
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="semesterService"></param>
        public SemesterController(IMapper mapper, 
            ISemesterService semesterService)
        {
            _mapper = mapper;
            _semesterService = semesterService;
        }

        /// <summary>
        /// API version 1.0 | Roles: admin, user | Get all semesters in database | Support search by name
        /// </summary>
        /// <param name="semesterParameters"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [Cached(600)]
        public ActionResult<IEnumerable<SemesterReadViewModel>> GetAllSemesters(
            [FromQuery] SemesterParameters semesterParameters)
        {
            var semesters = _semesterService.GetAllSemesters(semesterParameters);

            var metaData = new
            {
                semesters.TotalCount,
                semesters.PageSize,
                semesters.CurrentPage,
                semesters.HasNext,
                semesters.HasPrevious
            };
            Response.Headers.Add("Semester-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<SemesterReadViewModel>>(semesters));
        }

        /// <summary>
        /// API version 1.0 | Roles: admin, user | Get semester by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSemesterBySemesterId")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [Cached(600)]
        public ActionResult<SemesterReadDetailViewModel> GetSemesterBySemesterId(string id)
        {
            var semester = _semesterService.GetSemesterBySemesterId(id);
            if (semester is not null)
            {
                return Ok(_mapper.Map<SemesterReadDetailViewModel>(semester));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Add a new semester into database 
        /// </summary>
        /// <param name="semester"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<SemesterReadViewModel> AddSemester(SemesterAddViewModel semester)
        {
            var isExisted = _semesterService.GetSemesterBySemesterId(semester.SemesterId);
            if (isExisted is not null)
            {
                return BadRequest("Semester Id is existed....");
            }

            var semesterModel = _mapper.Map<Semester>(semester);
            _semesterService.AddSemester(semesterModel);
            var semesterReadModel = _mapper.Map<SemesterReadViewModel>(semesterModel);

            return CreatedAtRoute(
                nameof(GetSemesterBySemesterId), 
                new { id = semesterReadModel.SemesterId }, semesterReadModel
            );
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Update infomation of a semester 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="semester"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult UpdateSemester(string id, SemesterUpdateViewModel semester)
        {
            var semesterModel = _semesterService.GetSemesterBySemesterId(id);
            if (semesterModel is null)
            {
                return NotFound();
            }
            _mapper.Map(semester, semesterModel);
            _semesterService.UpdateSemester(semesterModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Update semester | Support update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult PartialSemesterUpdate(string id, 
            JsonPatchDocument<SemesterUpdateViewModel> patchDoc)
        {
            var semesterModel = _semesterService.GetSemesterBySemesterId(id);
            if (semesterModel is null)
            {
                return NotFound();
            }
            var semesterToPatch = _mapper.Map<SemesterUpdateViewModel>(semesterModel);
            patchDoc.ApplyTo(semesterToPatch, ModelState);
            if (!TryValidateModel(semesterToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(semesterToPatch, semesterModel);
            _semesterService.UpdateSemester(semesterModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Remove a semester 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult RemoveSemester(string id)
        {
            var semesterModel = _semesterService.GetSemesterBySemesterId(id);
            if (semesterModel is null)
            {
                return NotFound();
            }
            _semesterService.RemoveSemester(semesterModel);
            return Ok("Remove Successfull!");
        }
    }
}
