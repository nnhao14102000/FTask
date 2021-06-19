using AutoMapper;
using FTask.Api.ViewModels.PlanSubjectViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.PlanSubjectBusinessService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// PlanSubject controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/plan-subjects")]
    [ApiVersion("1.0")]
    public class PlanSubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlanSubjectService _planSubjectService;

        /// <summary>
        /// Constructor DI AutoMapper and Task Category service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="planSubjectService"></param>
        public PlanSubjectController(IMapper mapper, IPlanSubjectService planSubjectService)
        {
            _mapper = mapper;
            _planSubjectService = planSubjectService;
        }

        /// <summary>
        /// API version 1 | Get all plan subjects, allow search by name 
        /// </summary>
        /// <param name="planSubjectParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<PlanSubjectReadViewModel>> GetAllPlanSubjects([FromQuery] PlanSubjectParameters planSubjectParameter)
        {
            var PlanSubject = _planSubjectService.GetAllPlanSubjects(planSubjectParameter);

            var metaData = new
            {
                PlanSubject.TotalCount,
                PlanSubject.PageSize,
                PlanSubject.CurrentPage,
                PlanSubject.HasNext,
                PlanSubject.HasPrevious
            };
            Response.Headers.Add("PlanSubject-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<PlanSubjectReadViewModel>>(PlanSubject));
        }

        /// <summary>
        /// API version 1 | Get plan subject by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPlanSubjectByPlanSubjectId")]
        [MapToApiVersion("1.0")]
        public ActionResult<PlanSubjectReadDetailViewModel> GetPlanSubjectByPlanSubjectId(int id)
        {
            var planSubject = _planSubjectService.GetPlanSubjectByPlanSubjectId(id);
            if (planSubject is not null)
            {
                return Ok(_mapper.Map<PlanSubjectReadDetailViewModel>(planSubject));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1 | Add a plan subject into database 
        /// </summary>
        /// <param name="planSubject"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<PlanSubjectReadViewModel> AddPlanSubject(PlanSubjectAddViewModel planSubject)
        {
            var planSubjectModel = _mapper.Map<PlanSubject>(planSubject);
            _planSubjectService.AddPlanSubject(planSubjectModel);
            var PlanSubjectReadModel = _mapper.Map<PlanSubjectReadViewModel>(planSubjectModel);

            return CreatedAtRoute(nameof(GetPlanSubjectByPlanSubjectId), new { id = PlanSubjectReadModel.PlanSubjectId }, PlanSubjectReadModel);
        }

        /// <summary>
        /// API version 1 | Update plan subject 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="planSubject"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdatePlanSubject(int id, PlanSubjectUpdateViewModel planSubject)
        {
            var planSubjectModel = _planSubjectService.GetPlanSubjectByPlanSubjectId(id);
            if (planSubjectModel is null)
            {
                return NotFound();
            }
            _mapper.Map(planSubject, planSubjectModel);
            _planSubjectService.UpdatePlanSubject(planSubjectModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Update plan subject by PATCH method...Allow update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialPlanSubjectUpdate(int id, JsonPatchDocument<PlanSubjectUpdateViewModel> patchDoc)
        {
            var planSubjectModel = _planSubjectService.GetPlanSubjectByPlanSubjectId(id);
            if (planSubjectModel is null)
            {
                return NotFound();
            }
            var planSubjectToPatch = _mapper.Map<PlanSubjectUpdateViewModel>(planSubjectModel);
            patchDoc.ApplyTo(planSubjectToPatch, ModelState);
            if (!TryValidateModel(planSubjectToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(planSubjectToPatch, planSubjectModel);
            _planSubjectService.UpdatePlanSubject(planSubjectModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Remove a plan subject 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult RemovePlanSubject(int id)
        {
            var planSubjectModel = _planSubjectService.GetPlanSubjectByPlanSubjectId(id);
            if (planSubjectModel is null)
            {
                return NotFound();
            }
            _planSubjectService.RemovePlanSubject(planSubjectModel);
            return NoContent();
        }
    }
}
