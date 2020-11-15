using System;
using System.Threading.Tasks;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApplyNow.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetWithResumeByIdAsync(int userId)
        {
            return await _appDbContext.Users.Include(x => x.Resume)
                .Include(x=>x.Resume.Educations)
                .Include(x => x.Resume.Experiences)
                .SingleOrDefaultAsync(x => x.Id == userId);
        }
    }
}
