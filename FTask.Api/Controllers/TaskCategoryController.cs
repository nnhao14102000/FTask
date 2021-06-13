using AutoMapper;
using FTask.Api.ViewModels.TaskCategoryViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.TaskCategoryBusinessService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// Subject group controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/task-category")]
    [ApiVersion("1.0")]
    public class TaskCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITaskCategoryService _taskCategoryService;

        /// <summary>
        /// Constructor DI AutoMapper and Subject group service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="taskCategoryService"></param>
        public TaskCategoryController(IMapper mapper, ITaskCategoryService taskCategoryService)
        {
            _mapper = mapper;
            _taskCategoryService = taskCategoryService;
        }

        /// <summary>
        /// Get all Task Category
        /// </summary>
        /// <param name="taskCategoryParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
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
        /// Get Task Category by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTaskCategoryByTaskCategoryId")]
        [MapToApiVersion("1.0")]
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
        /// Add a Task Category into database
        /// </summary>
        /// <param name="taskCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<TaskCategoryReadViewModel> AddTaskCategory(TaskCategoryAddViewModel taskCategory)
        {
            var taskCategoryModel = _mapper.Map<TaskCategory>(taskCategory);
            _taskCategoryService.AddTaskCategory(taskCategoryModel);
            var taskCategoryReadModel = _mapper.Map<TaskCategoryReadViewModel>(taskCategoryModel);

            return CreatedAtRoute(nameof(GetTaskCategoryByTaskCategoryId), new { id = taskCategoryReadModel.TaskCategoryId }, taskCategoryReadModel);
        }

        /// <summary>
        /// Update Task Category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskCategory"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
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
        /// Update Task Category by PATCH method...Allow update a single attribute
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
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
        /// Remove a Task Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
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
