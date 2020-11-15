using System;
using System.Collections.Generic;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Seeds
{
    public class ResumeSeed : IEntityTypeConfiguration<Resume>
    {
        private readonly int[] _ids;

        public ResumeSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Resume> builder)
        {

            builder.HasData(
                new Resume { Id = 1, Title = "Yazılım Uzmanı", UserId = _ids[0], CreatedDate = DateTime.Now},
                new Resume { Id = 2, Title = "Avukat",  UserId = _ids[1], CreatedDate = DateTime.Now }
                );
        }
    }
}
