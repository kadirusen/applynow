using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplyNow.Core.Models;

namespace ApplyNow.Core.Services
{
    public interface IApplyService : IService<Apply>
    {
        Task<Apply> GetWithResumeAndAnnouncementAsync(int applyId);

        Task<List<Apply>> GetWithAnnouncementById(int announcementId);

        Task<Apply> CreateApplyAsync(Apply apply);

    }
}
