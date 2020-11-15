using System;
using System.ComponentModel.DataAnnotations;

namespace ApplyNow.Core.Models
{
    public class Experience
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CompanyName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int ResumeId { get; set; }

    }
}
