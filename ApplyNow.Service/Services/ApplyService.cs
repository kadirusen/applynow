using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
using ApplyNow.Core.Services;
using ApplyNow.Core.UnitOfWorks;
using Dawn;

namespace ApplyNow.Service.Services
{
    public class ApplyService : Service<Apply>, IApplyService
    {
        public ApplyService(IUnitOfWorks unitOfWork, IRepository<Apply> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Apply> GetWithResumeAndAnnouncementAsync(int applyId)
        {
            Guard.Argument(applyId, nameof(applyId)).NotDefault();

            return await _unitOfWork.Applys.GetWithResumeAndAnnouncementAsync(applyId);
        }

        public async Task<List<Apply>> GetWithAnnouncementById(int announcementId)
        {
            Guard.Argument(announcementId, nameof(announcementId)).NotDefault();

            return await _unitOfWork.Applys.GetWithAnnouncementById(announcementId);

        }

        public async Task<Apply> CreateApplyAsync(Apply apply)
        {
            Guard.Argument(apply, nameof(apply)).NotNull();

            if (!await _unitOfWork.Resumes.Exists(x => x.Id == apply.ResumeId))
                return null; //TODO: service result {code:1001,message:"not found user",success:false}

            if (!await _unitOfWork.Announcements.Exists(x => x.Id == apply.AnnouncementId))
                return null; //TODO: service result {code:1001,message:"not found user",success:false}

            apply.CreatedDate = DateTime.Now;
            apply.IsActive = true;

            Announcement announcement = (_unitOfWork.Announcements.Where(x => x.Id == apply.AnnouncementId).Result).FirstOrDefault();
            var userChechAnnouncement = (_unitOfWork.Applys.Where(x => x.AnnouncementId == apply.AnnouncementId && x.ResumeId == apply.ResumeId).Result).FirstOrDefault();

            if (userChechAnnouncement != null) {
                return null; //TODO: service result {code:1001,message:"not found user",success:false}

            }

            if (apply.CreatedDate > announcement.EndDate) {
                return null; //TODO: service result {code:1001,message:"not found user",success:false}

            }

            await _unitOfWork.Applys.AddAsync(apply);
            await _unitOfWork.CommitAsync();

            return apply;

        }
    }
}
