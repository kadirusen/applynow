using System;
using System.ComponentModel.DataAnnotations;

namespace ApplyNow.Core.Models
{
    public class Education
    {

        public  int Id { get; set; }

        public  string Name { get; set; }

        public  string Department { get; set; }

        public  string EndDate { get; set; }

        public int ResumeId { get; set; }

    }
}
