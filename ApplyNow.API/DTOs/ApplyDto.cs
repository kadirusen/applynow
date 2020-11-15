using System;
using ApplyNow.Core.Models;

namespace ApplyNow.API.DTOs
{
    public class ApplyDto
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Announcement Announcement { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
