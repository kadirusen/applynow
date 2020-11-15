using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApplyNow.Core.Models
{
    public class Resume
    {

        public  int Id { get; set; }

        public string Title { get; set; }

        public  DateTime CreatedDate { get; set; }

        public  DateTime? UpdateDate { get; set; }

        public  bool IsActive { get; set; }

        public int UserId { get; set; }

        public ICollection<Education> Educations { get; set; }

        public ICollection<Experience> Experiences { get; set; }


    }
}
