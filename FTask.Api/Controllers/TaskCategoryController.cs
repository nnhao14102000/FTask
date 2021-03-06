using AutoMapper;
using FTask.Api.ViewModels.TaskCategoryViewModels;
using FTask.AuthDatabase.Models;
using FTask.Cache;
using FTask.Database.Models;
using FTask.Services.TaskCategoryBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// API version 1.0 | Task category controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/task-categories")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class TaskCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITaskCategoryService _taskCategoryService;

        /// <summary>
        /// Constructor inject auto mapper and task category services
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="taskCategoryService"></param>
        public TaskCategoryController(IMapper mapper, 
            ITaskCategoryService taskCategoryService)
        {
            _mapper = mapper;
            _taskCategoryService = taskCategoryService;
        }

        /// <summary>
        /// API version 1.0 | Roles: admin, user | Get all task categories | Support search by name 
        /// </summary>
        /// <param name="taskCategoryParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [Cached(600)]
        public ActionResult<IEnumerable<TaskCategoryReadViewModel>> GetAllTaskCategories(
            [FromQuery] TaskCategoryParameters taskCategoryParameter)
        {
            var taskCategory = _taskCategoryService.GetAllTaskCategories(taskCategoryParameter);

            var metaData = new
            {
                taskCategory.TotalCount,
                taskCategory.PageSize,
                taskCategory.CurrentPage,
                taskCategory.HasNext,
                taskCategory.HasPrevious
            };
            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<TaskCategoryReadViewModel>>(taskCategory));
        }

        /// <summary>
        /// API version 1.0 | Roles: admin, user | Get task category by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTaskCategoryByTaskCategoryId")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [Cached(600)]
        public ActionResult<TaskCategoryReadDetailViewModel> GetTaskCategoryByTaskCategoryId(int id)
        {
            var taskCategory = _taskCategoryService.GetTaskCategoryByTaskCategoryId(id);
            if (taskCategory is not null)
            {
                return Ok(_mapper.Map<TaskCategoryReadDetailViewModel>(taskCategory));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Add a task category into database 
        /// </summary>
        /// <param name="taskCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<TaskCategoryReadViewModel> AddTaskCategory(TaskCategoryAddViewModel taskCategory)
        {
            var taskCategoryModel = _mapper.Map<TaskCategory>(taskCategory);
            _taskCategoryService.AddTaskCategory(taskCategoryModel);
            var taskCategoryReadModel = _mapper.Map<TaskCategoryReadViewModel>(taskCategoryModel);

            return CreatedAtRoute(
                nameof(GetTaskCategoryByTaskCategoryId), 
                new { id = taskCategoryReadModel.TaskCategoryId }, taskCategoryReadModel
            );
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Update task category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskCategory"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateTaskCategory(int id, TaskCategoryUpdateViewModel taskCategory)
        {
            var taskCategoryModel = _taskCategoryService.GetTaskCategoryByTaskCategoryId(id);
            if (taskCategoryModel is null)
            {
                return NotFound();
            }
            _mapper.Map(taskCategory, taskCategoryModel);
            _taskCategoryService.UpdateTaskCategory(taskCategoryModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Update task category | Support update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult PartialTaskCategoryUpdate(int id, 
            JsonPatchDocument<TaskCategoryUpdateViewModel> patchDoc)
        {
            var taskCategoryModel = _taskCategoryService.GetTaskCategoryByTaskCategoryId(id);
            if (taskCategoryModel is null)
            {
                return NotFound();
            }
            var taskCategoryToPatch = _mapper.Map<TaskCategoryUpdateViewModel>(taskCategoryModel);
            patchDoc.ApplyTo(taskCategoryToPatch, ModelState);
            if (!TryValidateModel(taskCategoryToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(taskCategoryToPatch, taskCategoryModel);
            _taskCategoryService.UpdateTaskCategory(taskCategoryModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1.0 | Roles: admin | Remove a task category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult RemoveTaskCategory(int id)
        {
            var taskCategoryModel = _taskCategoryService.GetTaskCategoryByTaskCategoryId(id);
            if (taskCategoryModel is null)
            {
                return NotFound();
            }
            _taskCategoryService.RemoveTaskCategory(taskCategoryModel);
            return Ok("Remove Successfull!");
        }
    }
}
