using System;
using System.Collections.Generic;

namespace ApplyNow.API.DTOs
{
    public class ResumeDto
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public IEnumerable<EducationDto> Educations { get; set; }

        public IEnumerable<ExperienceDto> Experiences { get; set; }

        public int UserId { get; set; }

    }
}
