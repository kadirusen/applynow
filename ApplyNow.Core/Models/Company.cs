using System;
using System.Collections.Generic;

namespace ApplyNow.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Announcement> Announcements { get; set; }

    }
}
