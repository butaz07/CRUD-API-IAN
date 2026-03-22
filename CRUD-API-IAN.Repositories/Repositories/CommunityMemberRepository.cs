using CRUD_API_IAN.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_API_IAN.Repositories.Repositories
{
    public class CommunityMemberRepository
    {
        private readonly ApplicationDbContext context;

        public CommunityMemberRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<CRUD_API_IAN.DOMAIN.ENTITIES.CommunityMember> GetAllCommunityMembers()
        {
            return context.CommunityMembers.ToList();
        }

        public CRUD_API_IAN.DOMAIN.ENTITIES.CommunityMember? GetCommunityMemberById(int id)
        {
            return context.CommunityMembers.FirstOrDefault(c => c.Id == id);
        }

        public void AddCommunityMember(CRUD_API_IAN.DOMAIN.ENTITIES.CommunityMember member)
        {
            
            context.CommunityMembers.Add(member);
        }

        public void UpdateCommunityMember(CRUD_API_IAN.DOMAIN.ENTITIES.CommunityMember member)
        {
           
            context.CommunityMembers.Update(member);
        }

        public void DeleteCommunityMember(int id)
        {
            var member = context.CommunityMembers.FirstOrDefault(c => c.Id == id);
            if (member != null)
            {
                
                context.CommunityMembers.Remove(member);
            }
        }
    }
}