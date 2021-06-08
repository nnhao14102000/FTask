using AutoMapper;
using FTask.Api.ViewModels.MajorViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.MajorService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    [ApiController]
    [Route("api/majors")]
    [ApiVersion("1.0")]
    public class MajorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMajorService _majorService;

        public MajorController(IMapper mapper, IMajorService MajorService)
        {
            _mapper = mapper;
            _majorService = MajorService;
        }

        [HttpGet]
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

        [HttpGet("{id}", Name = "GetMajorByMajorId")]
        public ActionResult<MajorReadDetailViewModel> GetMajorByMajorId(string id)
        {
            var major = _majorService.GetMajorByMajorId(id);
            if (major is not null)
            {
                return Ok(_mapper.Map<MajorReadDetailViewModel>(major));
            }
            return NotFound();
        }

        [HttpPost]
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

        [HttpPut("{id}")]
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

        [HttpPatch("{id}")]
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

        [HttpDelete("{id}")]
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
