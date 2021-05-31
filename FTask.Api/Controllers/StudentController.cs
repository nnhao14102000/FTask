using AutoMapper;
using FTask.Api.Dtos.StudentDtos;
using FTask.Data.Models;
using FTask.Services.StudentService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FTaskAPI.Controllers
{
    [Route("api/v{version:apiVersion}/students")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentController(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }

        [HttpGet("{id}", Name = "GetStudentByStudentId")]
        [MapToApiVersion("1.0")]
        public ActionResult<StudentReadDto> GetStudentByStudentId(string id)
        {
            var student = _studentService.GetStudentByStudentId(id);
            if (student is not null)
            {
                return Ok(_mapper.Map<StudentReadDto>(student));
            }
            return NotFound();
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<StudentReadDto> AddStudent(StudentAddDto student)
        {
            var isExisted = _studentService.GetStudentByStudentId(student.Id);
            if (isExisted is not null)
            {
                return BadRequest();
            }

            var studentModel = _mapper.Map<Student>(student);
            _studentService.AddStudent(studentModel);
            var studentReadModel = _mapper.Map<StudentReadDto>(studentModel);

            return CreatedAtRoute(nameof(GetStudentByStudentId), new { id = studentReadModel.Id }, studentReadModel);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdateStudent(string id, StudentUpdateDto student)
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

        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialStudentUpdate(string id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var studentModel = _studentService.GetStudentByStudentId(id);
            if(studentModel is null)
            {
                return NotFound();
            }
            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModel);
            patchDoc.ApplyTo(studentToPatch, ModelState);
            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, studentModel);
            _studentService.UpdateStudent(studentModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
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
