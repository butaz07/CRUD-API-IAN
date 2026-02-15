using CRUD_API_IAN.Data;
using CRUD_API_IAN.DTOs;
using CRUD_API_IAN.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CRUD_API_IAN.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class StudentsController : ControllerBase    
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<List<StudentReadDto>>> GetStudents()
        {
            // Seleccionamos solo Estudiantes y mapeamos manualmente a DTO
            var students = await _context.Students
                .Select(s => new StudentReadDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    StudentID = s.StudentID,
                    Carrier = s.Carrier
                })
                .ToListAsync();

            return Ok(students);
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult> CreateStudent(StudentCreateDto studentDto)
        {
            // 1. Convertir DTO a Entidad
            var newStudent = new Student
            {
                Name = studentDto.Name,
                Age = studentDto.Age,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                StudentID = studentDto.StudentID,
                Carrier = studentDto.Carrier,
                Average = 0 // Valor por defecto
            };

            // 2. Guardar en Base de Datos
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            // 3. Retornar éxito
            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Id }, studentDto);
        }
    }
}