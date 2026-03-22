namespace CRUD_API_IAN.DTO
{
    public class CommunityMemberCreateDto
    {
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }

}