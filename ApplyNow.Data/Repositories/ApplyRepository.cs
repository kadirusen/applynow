using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApplyNow.Data.Repositories
{
    public class ApplyRepository : Repository<Apply>, IApplyRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public ApplyRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<Apply> GetWithResumeAndAnnouncementAsync(int applyId)
        {
            return await _appDbContext.Applys.Include(x => x.Resume)
                .Include(x => x.Resume.Educations)
                .Include(x => x.Resume.Experiences)
                .Include(x => x.Announcement).SingleOrDefaultAsync(x => x.Id == applyId);
        }

        public async Task<List<Apply>> GetWithAnnouncementById(int announcementId)
        {
            return await _appDbContext.Applys.Include(x => x.Resume)
                .Include(x => x.Resume.Educations)
                .Include(x => x.Resume.Experiences)
                .Include(x => x.Announcement).Where(x => x.AnnouncementId == announcementId).ToListAsync();
        }
    }
}
