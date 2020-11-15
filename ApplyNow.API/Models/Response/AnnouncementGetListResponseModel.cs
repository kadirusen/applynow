using System;
using System.Collections.Generic;
using ApplyNow.API.DTOs;

namespace ApplyNow.API.Models.Response
{
    public class AnnouncementGetListResponseModel
    {
        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EndDate { get; set; }


        public List<ResumeDto> Resumes { get; set; }

    }
}
