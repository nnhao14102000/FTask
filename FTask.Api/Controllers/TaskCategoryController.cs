using AutoMapper;
using FTask.Api.ViewModels.TaskCategoryViewModels;
using FTask.AuthDatabase.Models;
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
    /// TaskCategory controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/task-category")]
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class TaskCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITaskCategoryService _taskCategoryService;

        /// <summary>
        /// Constructor DI AutoMapper and task category service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="taskCategoryService"></param>
        public TaskCategoryController(IMapper mapper, ITaskCategoryService taskCategoryService)
        {
            _mapper = mapper;
            _taskCategoryService = taskCategoryService;
        }

        /// <summary>
        /// API version 1 | Get all task category, allow search by name 
        /// </summary>
        /// <param name="taskCategoryParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        public ActionResult<IEnumerable<TaskCategoryReadViewModel>> GetAllTaskCategorys([FromQuery] TaskCategoryParameters taskCategoryParameter)
        {
            var taskCategory = _taskCategoryService.GetAllTaskCategorys(taskCategoryParameter);

            var metaData = new
            {
                taskCategory.TotalCount,
                taskCategory.PageSize,
                taskCategory.CurrentPage,
                taskCategory.HasNext,
                taskCategory.HasPrevious
            };
            Response.Headers.Add("TaskCategory-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<TaskCategoryReadViewModel>>(taskCategory));
        }

        /// <summary>
        /// API version 1 | Get task category by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTaskCategoryByTaskCategoryId")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
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
        /// API version 1 | Add a task category into database 
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

            return CreatedAtRoute(nameof(GetTaskCategoryByTaskCategoryId), new { id = taskCategoryReadModel.TaskCategoryId }, taskCategoryReadModel);
        }

        /// <summary>
        /// API version 1 | Update task category
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
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Update task category by PATCH method...Allow update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult PartialTaskCategoryUpdate(int id, JsonPatchDocument<TaskCategoryUpdateViewModel> patchDoc)
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
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Remove a task category
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
            return NoContent();
        }
    }
}
