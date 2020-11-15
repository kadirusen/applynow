using System;
using System.Collections;
using System.Collections.Generic;

namespace ApplyNow.API.DTOs
{
    public class CompanyWithAnnouncementDto : CompanyDto
    {
        public IEnumerable<AnnouncementDto> Announcements { get; set; }

    }
}
