using CRUD_API_IAN.DOMAIN.ENTITIES;

using CRUD_API_IAN.DTOs;
using CRUD_API_IAN.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_API_IAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
     
        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<List<StudentReadDto>> GetStudents()
        {
            
            var students = _unitOfWork.Students.GetAllStudents()
                .Select(s => new StudentReadDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    StudentID = s.StudentID,
                    Carrier = s.Carrier
                })
                .ToList();

            return Ok(students);
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentCreateDto studentDto)
        {
            var newStudent = new Student
            {
                Name = studentDto.Name,
                Age = studentDto.Age,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                StudentID = studentDto.StudentID,
                Carrier = studentDto.Carrier,
                Average = 0
            };

            
            _unitOfWork.Students.AddStudent(newStudent);

           
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Id }, studentDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentCreateDto studentDto)
        {
            var student = _unitOfWork.Students.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Manín, ese estudiante no existe.");
            }

            student.Name = studentDto.Name;
            student.Age = studentDto.Age;
            student.Email = studentDto.Email;
            student.Phone = studentDto.Phone;
            student.StudentID = studentDto.StudentID;
            student.Carrier = studentDto.Carrier;

            _unitOfWork.Students.UpdateStudent(student);
            _unitOfWork.Save(); 

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _unitOfWork.Students.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Manín, ese estudiante no se encontró.");
            }

            _unitOfWork.Students.DeleteStudent(id);
            _unitOfWork.Save(); 

            return NoContent();
        }
    }
}