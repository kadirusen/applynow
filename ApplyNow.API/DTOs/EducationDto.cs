using System;
namespace ApplyNow.API.DTOs
{
    public class EducationDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string EndDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
