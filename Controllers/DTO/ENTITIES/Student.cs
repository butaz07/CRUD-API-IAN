using CRUD_API_IAN.Entities;

namespace CRUD_API_IAN.Entities
{
    public class Student : CommunityMember
    {
        public string StudentID { get; set; } 
        public double Average { get; set; }
        public string Carrier { get; set; }
    }
}