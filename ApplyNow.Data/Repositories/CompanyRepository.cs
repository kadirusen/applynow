using System;
using System.Threading.Tasks;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApplyNow.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Company> GetWithAnnouncementByIdAsync(int companyId)
        {
            return await _appDbContext.Companies.Include(x => x.Announcements).SingleOrDefaultAsync(x => x.Id == companyId);
        }
    }
}
