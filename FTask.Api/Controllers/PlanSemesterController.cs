﻿using AutoMapper;
using FTask.Api.ViewModels.PlanSemesterViewModels;
using FTask.AuthDatabase.Models;
using FTask.Database.Models;
using FTask.Services.PlanSemesterBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// PlanSemester controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/plan-semester")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.User)]
    public class PlanSemesterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlanSemesterService _planSemesterService;

        /// <summary>
        /// Constructor DI AutoMapper and Task Category service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="planSemesterService"></param>
        public PlanSemesterController(IMapper mapper, IPlanSemesterService planSemesterService)
        {
            _mapper = mapper;
            _planSemesterService = planSemesterService;
        }

        /// <summary>
        /// API version 1 | Get all plan semester, allow search by name 
        /// </summary>
        /// <param name="planSemesterParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<PlanSemesterReadViewModel>> GetAllPlanSemesters([FromQuery] PlanSemesterParameters planSemesterParameter)
        {
            var planSemester = _planSemesterService.GetAllPlanSemesters(planSemesterParameter);

            var metaData = new
            {
                planSemester.TotalCount,
                planSemester.PageSize,
                planSemester.CurrentPage,
                planSemester.HasNext,
                planSemester.HasPrevious
            };
            Response.Headers.Add("PlanSemester-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<PlanSemesterReadViewModel>>(planSemester));
        }

        /// <summary>
        /// API version 1 | Get plan semester by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPlanSemesterByPlanSemesterId")]
        [MapToApiVersion("1.0")]
        public ActionResult<PSReadDetailViewModel> GetPlanSemesterByPlanSemesterId(int id)
        {
            var planSemester = _planSemesterService.GetPlanSemesterByPlanSemesterId(id);
            if (planSemester is not null)
            {
                return Ok(_mapper.Map<PSReadDetailViewModel>(planSemester));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1 | Add a plan semester into database 
        /// </summary>
        /// <param name="planSemester"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<PlanSemesterReadViewModel> AddPlanSemester(PlanSemesterAddViewModel planSemester)
        {
            var planSemesterModel = _mapper.Map<PlanSemester>(planSemester);
            _planSemesterService.AddPlanSemester(planSemesterModel);
            var PlanSemesterReadModel = _mapper.Map<PlanSemesterReadViewModel>(planSemesterModel);

            return CreatedAtRoute(nameof(GetPlanSemesterByPlanSemesterId), new { id = PlanSemesterReadModel.PlanSemesterId }, PlanSemesterReadModel);
        }

        /// <summary>
        /// API version 1 | Update plan semester 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="planSemester"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdatePlanSemester(int id, PlanSemesterUpdateViewModel planSemester)
        {
            var planSemesterModel = _planSemesterService.GetPlanSemesterByPlanSemesterId(id);
            if (planSemesterModel is null)
            {
                return NotFound();
            }
            _mapper.Map(planSemester, planSemesterModel);
            _planSemesterService.UpdatePlanSemester(planSemesterModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Update plan semester by PATCH method...Allow update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialPlanSemesterUpdate(int id, JsonPatchDocument<PlanSemesterUpdateViewModel> patchDoc)
        {
            var planSemesterModel = _planSemesterService.GetPlanSemesterByPlanSemesterId(id);
            if (planSemesterModel is null)
            {
                return NotFound();
            }
            var planSemesterToPatch = _mapper.Map<PlanSemesterUpdateViewModel>(planSemesterModel);
            patchDoc.ApplyTo(planSemesterToPatch, ModelState);
            if (!TryValidateModel(planSemesterToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(planSemesterToPatch, planSemesterModel);
            _planSemesterService.UpdatePlanSemester(planSemesterModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Remove a plan semester 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult RemovePlanSemester(int id)
        {
            var planSemesterModel = _planSemesterService.GetPlanSemesterByPlanSemesterId(id);
            if (planSemesterModel is null)
            {
                return NotFound();
            }
            _planSemesterService.RemovePlanSemester(planSemesterModel);
            return NoContent();
        }
    }
}
