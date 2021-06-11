using AutoMapper;
using FTask.Api.ViewModels.StudentViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.StudentBusinessService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    /// <summary>
    /// Student controller
    /// </summary>
    [ApiController]
    [Route("api/students")]
    [ApiVersion("1.0")]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        /// <summary>
        /// Constructor DI AutoMapper and Student service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="studentService"></param>
        public StudentController(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        /// <summary>
        /// Get all student
        /// </summary>
        /// <param name="studentParameters"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadViewModel>> GetAllStudents([FromQuery] StudentParameters studentParameters)
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
        /// Get student by student ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetStudentByStudentId")]
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
        /// Add a new student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
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

            return CreatedAtRoute(nameof(GetStudentByStudentId), new { id = studentReadModel.StudentId }, studentReadModel);
        }

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(string id, StudentUpdateViewModel student)
        {
            var studentModel = _studentService.GetStudentByStudentId(id);
            if(studentModel is null)
            {
                return NotFound();
            }
            _mapper.Map(student, studentModel);
            _studentService.UpdateStudent(studentModel);
            return NoContent();
        }

        /// <summary>
        /// Update student by PATCH method...Allow update a single attribute
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult PartialStudentUpdate(string id, JsonPatchDocument<StudentUpdateViewModel> patchDoc)
        {
            var studentModel = _studentService.GetStudentByStudentId(id);
            if(studentModel is null)
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
            return NoContent();
        }

        /// <summary>
        /// Remove student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult RemoveStudent(string id)
        {
            var studentModel = _studentService.GetStudentByStudentId(id);
            if (studentModel is null)
            {
                return NotFound();
            }
            _studentService.RemoveStudent(studentModel);
            return NoContent();
        }

    }
}
