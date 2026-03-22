namespace CRUD_API_IAN.Controllers.DTO
{
    public class CommunityMemberReadDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}