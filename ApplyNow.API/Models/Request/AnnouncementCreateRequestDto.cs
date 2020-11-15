using System;
using System.Collections.Generic;

namespace ApplyNow.API.Models.Request
{
    public class AnnouncementCreateRequestDto
    {
        public IEnumerable<AnnouncementRequestDto> Announcements { get; set; }


        public class AnnouncementRequestDto
        {
            public string Description { get; set; }
            public string Location { get; set; }
            public string EndDate { get; set; }
        }

    }
}
