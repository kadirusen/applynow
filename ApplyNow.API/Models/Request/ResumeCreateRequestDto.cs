using System;
using System.Collections.Generic;

namespace ApplyNow.API.Models.Request
{
    public class ResumeCreateRequestDto
    {
        public string Title { get; set; }

        public IEnumerable<Experience> Experiences { get; set; }
        public IEnumerable<EducationRequestDto> Educations { get; set; }


        public class Experience
        {
            public string Title { get; set; }
            public string CompanyName { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }

        public class EducationRequestDto
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public string EndDate { get; set; }
        }


    }
}