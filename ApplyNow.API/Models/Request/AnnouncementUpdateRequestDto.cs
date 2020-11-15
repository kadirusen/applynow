using System;
namespace ApplyNow.API.Models.Request
{
    public class AnnouncementUpdateRequestDto
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public string EndDate { get; set; }
    }
}
