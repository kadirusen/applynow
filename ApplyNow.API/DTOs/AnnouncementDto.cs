using System;
namespace ApplyNow.API.DTOs
{
    public class AnnouncementDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
