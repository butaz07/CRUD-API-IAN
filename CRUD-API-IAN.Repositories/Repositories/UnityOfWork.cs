using CRUD_API_IAN.Persistence;

namespace CRUD_API_IAN.Repositories.Repositories
{
  
    public interface IUnitOfWork : IDisposable
    {
        StudentRepository Students { get; }
        CommunityMemberRepository CommunityMembers { get; }
        int Save();
    }

   
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository Students { get; private set; }
        public CommunityMemberRepository CommunityMembers { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Students = new StudentRepository(_context);
            CommunityMembers = new CommunityMemberRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
