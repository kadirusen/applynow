using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplyNow.Core.Models;

namespace ApplyNow.Core.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<Company> GetWithAnnouncementByIdAsync(int companyId);

        Company UpdateCompany(int companyId, Company company);

        Task<List<Announcement>> CreateAnnouncementAsync(int companyId, List<Announcement> announcements);

        Announcement UpdateAnnouncementAsync(int companyId, int announcementId, Announcement announcement);

        void RemoveWithAnnouncement(int companyId);


        void RemoveWithAnnouncementById(int companyId, int announcementId);

    }
}
