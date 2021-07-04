using AutoMapper;
using FTask.Api.ViewModels.PlanTopicViewModels;
using FTask.AuthDatabase.Models;
using FTask.Database.Models;
using FTask.Services.PlanTopicBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// PlanTopic controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/plan-topics")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.User)]
    public class PlanTopicController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlanTopicService _planTopicService;

        /// <summary>
        /// Constructor DI AutoMapper and Task Category service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="planTopicService"></param>
        public PlanTopicController(IMapper mapper, IPlanTopicService planTopicService)
        {
            _mapper = mapper;
            _planTopicService = planTopicService;
        }

        /// <summary>
        /// API version 1 | Roles: user | Get all plan topic, allow search by name 
        /// </summary>
        /// <param name="planTopicParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<PlanTopicReadViewModel>> GetAllPlanTopics([FromQuery] PlanTopicParameters planTopicParameter)
        {
            var planTopic = _planTopicService.GetAllPlanTopics(planTopicParameter);

            var metaData = new
            {
                planTopic.TotalCount,
                planTopic.PageSize,
                planTopic.CurrentPage,
                planTopic.HasNext,
                planTopic.HasPrevious
            };
            Response.Headers.Add("PlanTopic-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<PlanTopicReadViewModel>>(planTopic));
        }

        /// <summary>
        /// API version 1 | Roles: user | Get plan topic by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPlanTopicByPlanTopicId")]
        [MapToApiVersion("1.0")]
        public ActionResult<PlanTopicReadDetailViewModel> GetPlanTopicByPlanTopicId(int id)
        {
            var planTopic = _planTopicService.GetPlanTopicByPlanTopicId(id);
            if (planTopic is not null)
            {
                return Ok(_mapper.Map<PlanTopicReadDetailViewModel>(planTopic));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1 | Roles: user | Add a plan topic into database 
        /// </summary>
        /// <param name="planTopic"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<PlanTopicReadViewModel> AddPlanTopic(PlanTopicAddViewModel planTopic)
        {
            var planTopicModel = _mapper.Map<PlanTopic>(planTopic);
            _planTopicService.AddPlanTopic(planTopicModel);
            var PlanTopicReadModel = _mapper.Map<PlanTopicReadViewModel>(planTopicModel);

            return CreatedAtRoute(nameof(GetPlanTopicByPlanTopicId), new { id = PlanTopicReadModel.PlanTopicId }, PlanTopicReadModel);
        }

        /// <summary>
        /// API version 1 | Roles: user | Update plan topic 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="planTopic"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdatePlanTopic(int id, PlanTopicUpdateViewModel planTopic)
        {
            var planTopicModel = _planTopicService.GetPlanTopicByPlanTopicId(id);
            if (planTopicModel is null)
            {
                return NotFound();
            }
            _mapper.Map(planTopic, planTopicModel);
            _planTopicService.UpdatePlanTopic(planTopicModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Roles: user | Update plan topic by PATCH method...Allow update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialPlanTopicUpdate(int id, JsonPatchDocument<PlanTopicUpdateViewModel> patchDoc)
        {
            var planTopicModel = _planTopicService.GetPlanTopicByPlanTopicId(id);
            if (planTopicModel is null)
            {
                return NotFound();
            }
            var planTopicToPatch = _mapper.Map<PlanTopicUpdateViewModel>(planTopicModel);
            patchDoc.ApplyTo(planTopicToPatch, ModelState);
            if (!TryValidateModel(planTopicToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(planTopicToPatch, planTopicModel);
            _planTopicService.UpdatePlanTopic(planTopicModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Roles: user | Remove a plan topic 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult RemovePlanTopic(int id)
        {
            var planTopicModel = _planTopicService.GetPlanTopicByPlanTopicId(id);
            if (planTopicModel is null)
            {
                return NotFound();
            }
            _planTopicService.RemovePlanTopic(planTopicModel);
            return NoContent();
        }
    }
}
