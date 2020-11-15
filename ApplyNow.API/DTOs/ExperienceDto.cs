using System;
namespace ApplyNow.API.DTOs
{
    public class ExperienceDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CompanyName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
