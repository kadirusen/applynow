using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Seeds
{
    public class ApplySeed : IEntityTypeConfiguration<Apply>
    {
        private readonly int[] _ids;

        public ApplySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Apply> builder)
        {
            builder.HasData(
                new Apply { Id = 1, AnnouncementId = 1, ResumeId = 1, CreatedDate = DateTime.Now, IsActive = true },
                new Apply { Id = 2, AnnouncementId = 1, ResumeId = 2, CreatedDate = DateTime.Now, IsActive = true },
                new Apply { Id = 3, AnnouncementId = 2, ResumeId = 1, CreatedDate = DateTime.Now, IsActive = true }
                );
        }
    }
}
