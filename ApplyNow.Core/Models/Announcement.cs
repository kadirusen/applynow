using System;
namespace ApplyNow.Core.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CompanyId { get; set; }

    }
}
