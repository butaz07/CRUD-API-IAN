using CRUD_API_IAN.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_API_IAN.Repositories.Repositories
{
    public class StudentRepository
    {
        private readonly ApplicationDbContext context;

        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<CRUD_API_IAN.DOMAIN.ENTITIES.Student> GetAllStudents()
        {
            return context.Student.ToList();
        }

        public CRUD_API_IAN.DOMAIN.ENTITIES.Student? GetStudentById(int id)
        {
            return context.Student.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(CRUD_API_IAN.DOMAIN.ENTITIES.Student student)
        {
            
            context.Student.Add(student);
        }

        public void UpdateStudent(CRUD_API_IAN.DOMAIN.ENTITIES.Student student)
        {
            
            context.Student.Update(student);
        }

        public void DeleteStudent(int id)
        {
            var student = context.Student.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
               
                context.Student.Remove(student);
            }
        }
    }
}