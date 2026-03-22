namespace CRUD_API_IAN.DOMAIN.ENTITIES
{
    public class Student : CommunityMember
    {
        public required string StudentID { get; set; } 
        public double Average { get; set; }
        public required string Carrier { get; set; }
    }
}