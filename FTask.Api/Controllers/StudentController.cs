using AutoMapper;
using FTask.Api.ViewModels.StudentViewModels;
using FTask.AuthDatabase.Models;
using FTask.Database.Models;
using FTask.Services.StudentBusinessService;
using FTask.Shared.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    /// <summary>
    /// API version 1.0 | Student controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/students")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IStudentService _studentService;

        /// <summary>
        /// API version 1 and 1.1 | Constructor inject auto mapper and student services
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="studentService"></param>
        public StudentController(IMapper mapper, 
            IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        /// <summary>
        /// API version 1 | Roles: admin | Get all students | Support search by name, filter by major Id 
        /// </summary>
        /// <param name="studentParameters"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<IEnumerable<StudentReadViewModel>> GetAllStudents(
            [FromQuery] StudentParameters studentParameters)
        {
            var students = _studentService.GetAllStudents(studentParameters);

            var metaData = new
            {
                students.TotalCount,
                students.PageSize,
                students.CurrentPage,
                students.HasNext,
                students.HasPrevious
            };
            Response.Headers.Add("Student-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<StudentReadViewModel>>(students));
        }

        /// <summary>
        /// API version 1 | Roles: admin, user | Get student by student Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetStudentByStudentId")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        public ActionResult<StudentReadDetailViewModel> GetStudentByStudentId(string id)
        {
            var student = _studentService.GetStudentByStudentId(id);
            if (student is not null)
            {
                return Ok(_mapper.Map<StudentReadDetailViewModel>(student));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1.1 | Roles: admin, user | Get student by student email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("{email}", Name = "GetStudentByStudentEmail")]
        [MapToApiVersion("1.1")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        public ActionResult<StudentReadDetailViewModel> GetStudentByStudentEmail(string email)
        {
            var student = _studentService.GetStudentByStudentEmail(email);
            if (student is not null)
            {
                return Ok(_mapper.Map<StudentReadDetailViewModel>(student));
            }
            return NotFound();
        }

        /// <summary>
        /// API version 1 | Roles: admin | Add a new student 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<StudentReadViewModel> AddStudent(StudentAddViewModel student)
        {
            var isExisted = _studentService.GetStudentByStudentId(student.StudentId);
            if (isExisted is not null)
            {
                return BadRequest("Student Id is existed....");
            }

            var studentModel = _mapper.Map<Student>(student);
            _studentService.AddStudent(studentModel);
            var studentReadModel = _mapper.Map<StudentReadViewModel>(studentModel);

            return CreatedAtRoute(
                nameof(GetStudentByStudentId), 
                new { id = studentReadModel.StudentId }, studentReadModel
            );
        }

        /// <summary>
        /// API version 1 | Roles: admin, user | Update student 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        public ActionResult UpdateStudent(string id, StudentUpdateViewModel student)
        {
            var studentModel = _studentService.GetStudentByStudentId(id);
            if (studentModel is null)
            {
                return NotFound();
            }
            _mapper.Map(student, studentModel);
            _studentService.UpdateStudent(studentModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1 | Roles: admin, user | Update student | Support update a single attribute 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        public ActionResult PartialStudentUpdate(string id, 
            JsonPatchDocument<StudentUpdateViewModel> patchDoc)
        {
            var studentModel = _studentService.GetStudentByStudentId(id);
            if (studentModel is null)
            {
                return NotFound();
            }
            var studentToPatch = _mapper.Map<StudentUpdateViewModel>(studentModel);
            patchDoc.ApplyTo(studentToPatch, ModelState);
            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, studentModel);
            _studentService.UpdateStudent(studentModel);
            return Ok("Update Successfull!");
        }

        /// <summary>
        /// API version 1 | Roles: admin | Remove student 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult RemoveStudent(string id)
        {
            var studentModel = _studentService.GetStudentByStudentId(id);
            if (studentModel is null)
            {
                return NotFound();
            }
            _studentService.RemoveStudent(studentModel);
            return Ok("Remove Successfull!");
        }

    }
}
