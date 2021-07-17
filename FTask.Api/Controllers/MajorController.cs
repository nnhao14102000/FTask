using AutoMapper;
using FTask.Api.ViewModels.MajorViewModels;
using FTask.AuthDatabase.Models;
using FTask.Cache;
using FTask.Database.Models;
using FTask.Services.MajorBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    /// <summary>
    /// API version 1.0 | Major controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/majors")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class MajorController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IMajorService _majorService;

        /// <summary>
        /// Constructor inject auto mapper object and major services
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="MajorService"></param>
        public MajorController(IMapper mapper, IMajorService MajorService)
        {
            _mapper = mapper;
            _majorService = MajorService;
        }

        /// <summary>
        /// API version 1.0 | Roles: admin, user | Get all majors in database | Support search by major name
        /// </summary>
        /// <param name="majorParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [Cached(600)]
        public ActionResult<IEnumerable<MajorReadViewModel>> GetAllMajors(
            [FromQuery] MajorParameters majorParameter)
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
        /// API version 1.0 | Roles: admin, user | Get major and relevant students in this major by major Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetMajorInDetailByMajorId")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [Cached(600)]
        public ActionResult<MajorReadDetailViewModel> GetMajorInDetailByMajorId(string id)
        {
            var major = _majorService.GetMajorInDetailByMajorId(id);
            if (major is not null)
            {
                return Ok(_mapper.Map<MajorReadDetailViewModel>(major));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Add a new major into database 
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
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

            return CreatedAtRoute(
                nameof(GetMajorInDetailByMajorId),
                new { id = majorReadModel.MajorId }, majorReadModel
            );
        }

        /// <summary>
        /// API version 1.0 | Roles: Admin | Update infomation of a major 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="major"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateMajor(string id, MajorUpdateViewModel major)
        {
            var majorModel = _majorService.GetMajorByMajorId(id);
            if (majorModel is null)
            {
                return NotFound();
            }
            _mapper.Map(major, majorModel);
            _majorService.UpdateMajor(majorModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: Admin | Update infomation of a major | Support update single attribute
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult PartialMajorUpdate(string id,
            JsonPatchDocument<MajorUpdateViewModel> patchDoc)
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
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: Admin | Remove a major 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult RemoveMajor(string id)
        {
            var majorModel = _majorService.GetMajorByMajorId(id);
            if (majorModel is null)
            {
                return NotFound();
            }
            _majorService.RemoveMajor(majorModel);
            return Ok("Remove Successfull!");
        }

    }
}
