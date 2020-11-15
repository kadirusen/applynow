using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ApplyNow.API.DTOs;
using ApplyNow.API.Models.Request;
using ApplyNow.Core.Models;

namespace ApplyNow.API.Mapping
{
    public static class CompanyWithAnnouncementMappingModel
    {
        public static List<Announcement> ToCompanyWithAnnouncementMappingModel(this AnnouncementCreateRequestDto model) {

            var newModel = new List<Announcement>();

            if (model != null && model.Announcements != null) {

                foreach (var item in model.Announcements)
                {
                    DateTime endDate = !string.IsNullOrWhiteSpace(item.EndDate) ? DateTime.ParseExact(item.EndDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) : DateTime.Now;

                    Announcement announcement = new Announcement
                    {
                        Description = item.Description,
                        Location = item.Location,
                        CreatedDate = DateTime.Now,
                        EndDate = endDate

                    };

                    newModel.Add(announcement);
                }

            }

            return newModel;

        }
    }
}
