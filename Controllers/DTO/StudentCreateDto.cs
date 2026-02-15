using System.ComponentModel.DataAnnotations;

namespace CRUD_API_IAN.DTOs
{
    public class StudentCreateDto
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required]
        public string StudentID { get; set; } 
        public string Carrier { get; set; }
    }
}