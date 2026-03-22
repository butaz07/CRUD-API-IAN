using System.ComponentModel.DataAnnotations;

namespace CRUD_API_IAN.DOMAIN.ENTITIES
{
    public class CommunityMember
    {
        [Key] 
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}