using AutoMapper;
using FTask.Api.ViewModels.TaskViewModels;
using FTask.Database.Models;
using FTask.Services.TaskBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// Task controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/tasks")]
    [ApiVersion("1.0")]
    public class TaskController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITaskService _taskService;

        /// <summary>
        /// Constructor DI AutoMapper and task service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="taskService"></param>
        public TaskController(IMapper mapper, ITaskService taskService)
        {
            _mapper = mapper;
            _taskService = taskService;
        }

        /// <summary>
        /// API version 1 | Get all task, allow search by name
        /// </summary>
        /// <param name="taskParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<TaskReadViewModel>> GetAllTasks([FromQuery] TaskParameters taskParameter)
        {
            var Task = _taskService.GetAllTasks(taskParameter);

            var metaData = new
            {
                Task.TotalCount,
                Task.PageSize,
                Task.CurrentPage,
                Task.HasNext,
                Task.HasPrevious
            };
            Response.Headers.Add("Task-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<TaskReadViewModel>>(Task));
        }

        /// <summary>
        /// API version 1 | Get task by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTaskByTaskId")]
        [MapToApiVersion("1.0")]
        public ActionResult<TaskReadViewModel> GetTaskByTaskId(int id)
        {
            var Task = _taskService.GetTaskByTaskId(id);
            if (Task is not null)
            {
                return Ok(_mapper.Map<TaskReadViewModel>(Task));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1 | Add a task into database
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<TaskReadViewModel> AddTask(TaskAddViewModel task)
        {
            var taskModel = _mapper.Map<Task>(task);
            _taskService.AddTask(taskModel);
            var TaskReadModel = _mapper.Map<TaskReadViewModel>(taskModel);

            return CreatedAtRoute(nameof(GetTaskByTaskId), new { id = TaskReadModel.TaskId }, TaskReadModel);
        }

        /// <summary>
        /// API version 1 | Update task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdateTask(int id, TaskUpdateViewModel task)
        {
            var taskModel = _taskService.GetTaskByTaskId(id);
            if (taskModel is null)
            {
                return NotFound();
            }
            _mapper.Map(task, taskModel);
            _taskService.UpdateTask(taskModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Update task by PATCH method...Allow update a single attribute
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialTaskUpdate(int id, JsonPatchDocument<TaskUpdateViewModel> patchDoc)
        {
            var taskModel = _taskService.GetTaskByTaskId(id);
            if (taskModel is null)
            {
                return NotFound();
            }
            var taskToPatch = _mapper.Map<TaskUpdateViewModel>(taskModel);
            patchDoc.ApplyTo(taskToPatch, ModelState);
            if (!TryValidateModel(taskToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(taskToPatch, taskModel);
            _taskService.UpdateTask(taskModel);
            return NoContent();
        }

        /// <summary>
        /// API version 1 | Remove a task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult RemoveTask(int id)
        {
            var taskModel = _taskService.GetTaskByTaskId(id);
            if (taskModel is null)
            {
                return NotFound();
            }
            _taskService.RemoveTask(taskModel);
            return NoContent();
        }
    }
}
