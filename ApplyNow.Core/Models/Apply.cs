using System;
using System.Collections.Generic;

namespace ApplyNow.Core.Models
{
    public class Apply
    {
        public int Id { get; set; }

        public int AnnouncementId { get; set; }

        public int ResumeId { get; set;  }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public Announcement Announcement { get; set; }

        public Resume Resume { get; set; }


    }
}
