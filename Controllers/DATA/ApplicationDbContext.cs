using CRUD_API_IAN.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace CRUD_API_IAN.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       
        public DbSet<CommunityMember> CommunityMembers { get; set; }
        public DbSet<Student> Students { get; set; }
       
    }
}