using System;
using System.Globalization;
using ApplyNow.API.Models.Request;
using ApplyNow.Core.Models;

namespace ApplyNow.API.Mapping
{
    public static class AnnouncementUpdateMappingModel
    {
        public static Announcement ToAnnouncementUpdateMappingModel(this AnnouncementUpdateRequestDto model)
        {

            if (model != null)
            {
                
                DateTime endDate = !string.IsNullOrWhiteSpace(model.EndDate) ? DateTime.ParseExact(model.EndDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) : DateTime.Now;

                Announcement announcement = new Announcement
                {
                    Description = model.Description,
                    Location = model.Location,
                    CreatedDate = DateTime.Now,
                    EndDate = endDate

                };

                return announcement;

            }

            return null;
        }
    }
}
