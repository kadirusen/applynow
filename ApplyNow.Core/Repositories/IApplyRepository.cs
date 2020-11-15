using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplyNow.Core.Models;

namespace ApplyNow.Core.Repositories
{
    public interface IApplyRepository : IRepository<Apply>
    {
        Task<Apply> GetWithResumeAndAnnouncementAsync(int applyId);
        Task<List<Apply>> GetWithAnnouncementById(int announcementId);
    }
}
