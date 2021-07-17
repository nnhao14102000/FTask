using AutoMapper;
using FTask.Api.ViewModels.PlanSubjectViewModels;
using FTask.AuthDatabase.Models;
using FTask.Cache;
using FTask.Database.Models;
using FTask.Services.PlanSubjectBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// API version 1.0 | Plan subject controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/plan-subjects")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.User)]
    public class PlanSubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlanSubjectService _planSubjectService;

        /// <summary>
        /// Constructor inject auto mapper and plan subject services
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="planSubjectService"></param>
        public PlanSubjectController(IMapper mapper, 
            IPlanSubjectService planSubjectService)
        {
            _mapper = mapper;
            _planSubjectService = planSubjectService;
        }

        /// <summary>
        /// API version 1.0 | Roles: user | Get all plan subjects | Support get by plan semester Id and filter by it status (is complete)
        /// </summary>
        /// <param name="planSubjectParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Cached(600)]
        public ActionResult<IEnumerable<PlanSubjectReadViewModel>> GetAllPlanSubjects(
            [FromQuery] PlanSubjectParameters planSubjectParameter)
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
        /// API version 1.0 | Roles: user | Get plan subject by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPlanSubjectByPlanSubjectId")]
        [MapToApiVersion("1.0")]
        [Cached(600)]
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
        /// API version 1.0 | Roles: user | Add a plan subject into database 
        /// </summary>
        /// <param name="planSubject"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<PlanSubjectReadViewModel> AddPlanSubject(
            PlanSubjectAddViewModel planSubject)
        {
            var planSubjectModel = _mapper.Map<PlanSubject>(planSubject);
            _planSubjectService.AddPlanSubject(planSubjectModel);
            var PlanSubjectReadModel = _mapper.Map<PlanSubjectReadViewModel>(planSubjectModel);

            return CreatedAtRoute(
                nameof(GetPlanSubjectByPlanSubjectId), 
                new { id = PlanSubjectReadModel.PlanSubjectId }, PlanSubjectReadModel);
        }

        /// <summary>
        /// API version 1.0 | Roles: user | Update plan subject 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="planSubject"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdatePlanSubject(int id, 
            PlanSubjectUpdateViewModel planSubject)
        {
            var planSubjectModel = _planSubjectService.GetPlanSubjectByPlanSubjectId(id);
            if (planSubjectModel is null)
            {
                return NotFound();
            }
            _mapper.Map(planSubject, planSubjectModel);
            _planSubjectService.UpdatePlanSubject(planSubjectModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: user | Update plan subject | Support update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialPlanSubjectUpdate(int id, 
            JsonPatchDocument<PlanSubjectUpdateViewModel> patchDoc)
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
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: user | Remove a plan subject 
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
            return Ok("Remove Successfull!");
        }
    }
}
