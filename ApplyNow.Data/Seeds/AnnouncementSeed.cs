using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Seeds
{
    public class AnnouncementSeed : IEntityTypeConfiguration<Announcement>
    {
        private readonly int[] _ids;

        public AnnouncementSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasData(
                new Announcement { Id = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", Location = "İstanbul", CreatedDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(2), CompanyId = _ids[0] },
                new Announcement { Id = _ids[1], Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", Location = "İzmir", CreatedDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now ,CompanyId = _ids[1] }
                );
        }
    }
}
