using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
using ApplyNow.Core.Services;
using ApplyNow.Core.UnitOfWorks;
using Dawn;

namespace ApplyNow.Service.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        public CompanyService(IUnitOfWorks unitOfWork, IRepository<Company> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Company> GetWithAnnouncementByIdAsync(int companyId)
        {
            return await _unitOfWork.Companies.GetWithAnnouncementByIdAsync(companyId);
        }

        public Company UpdateCompany(int companyId, Company company)
        {

            Guard.Argument(companyId, nameof(companyId)).NotDefault();

            company.Id = companyId;
            _unitOfWork.Companies.Update(company);
            _unitOfWork.Commit();

            return company;
        }

        public async Task<List<Announcement>> CreateAnnouncementAsync(int companyId, List<Announcement> announcements)
        {
            Guard.Argument(companyId, nameof(companyId)).NotDefault();
            Guard.Argument(announcements, nameof(announcements)).NotNull();


            if (!await _unitOfWork.Companies.Exists(x => x.Id == companyId))
                return null; //TODO: service result {code:1001,message:"not found user",success:false}

            if (announcements != null && announcements.Count > 0) {

                foreach (var item in announcements)
                {
                    Announcement newAnnouncement = new Announcement();

                    item.CompanyId = companyId;

                    await _unitOfWork.Announcements.AddAsync(item);
                    await _unitOfWork.CommitAsync();

                }

                return announcements;
            }

            return null;
        }

        public Announcement UpdateAnnouncementAsync(int companyId, int announcementId, Announcement announcement)
        {

            Guard.Argument(companyId, nameof(companyId)).NotDefault();
            Guard.Argument(announcementId, nameof(announcementId)).NotDefault();
            Guard.Argument(announcement, nameof(announcement)).NotNull();

            Guard.Argument(announcement.Description, nameof(announcement.Description)).NotNull().NotEmpty();

            announcement.Id = announcementId;
            announcement.CompanyId = companyId;

            _unitOfWork.Announcements.Update(announcement);
            _unitOfWork.Commit();

            return announcement;
        }


        public void RemoveWithAnnouncement(int companyId)
        {
            Guard.Argument(companyId, nameof(companyId)).NotDefault();

            List<Announcement> announcements = (_unitOfWork.Announcements.Where(x => x.CompanyId == companyId).Result).ToList();
            Company company = (_unitOfWork.Companies.Where(x => x.Id == companyId).Result).FirstOrDefault();

            if (announcements != null && announcements.Count > 0)
            {
                _unitOfWork.Announcements.RemoveRange(announcements);

            }

            _unitOfWork.Companies.Remove(company);
            _unitOfWork.Commit();
        }


        public void RemoveWithAnnouncementById(int companyId, int announcementId)
        {
            Guard.Argument(companyId, nameof(companyId)).NotDefault();
            Guard.Argument(announcementId, nameof(announcementId)).NotDefault();

            Announcement announcement = (_unitOfWork.Announcements.Where(x => x.Id == announcementId).Result).FirstOrDefault();

            if (announcement != null)
            {
                _unitOfWork.Announcements.Remove(announcement);
                _unitOfWork.Commit();
            }

        }
    }
}
