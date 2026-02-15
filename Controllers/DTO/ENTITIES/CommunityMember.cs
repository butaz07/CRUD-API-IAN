using System.ComponentModel.DataAnnotations;

namespace CRUD_API_IAN.Entities
{
    public abstract class CommunityMember
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}