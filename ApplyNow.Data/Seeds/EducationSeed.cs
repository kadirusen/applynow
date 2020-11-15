using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Seeds
{
    public class EducationSeed : IEntityTypeConfiguration<Education>
    {
        private readonly int[] _ids;

        public EducationSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasData(
                new Education { Id = 1, Name = "İstanbul Teknik Ünversitesi", Department = "Bilgisayar Mühendisliği", EndDate = "2014", ResumeId = _ids[0] },
                new Education { Id = 2, Name = "İstanbul Lisesi", Department = "Bilgisayar Programcılığı", EndDate = "2009", ResumeId = _ids[0] },
                new Education { Id = 3, Name = "Yıldız Teknik Üniversitesi", Department = "Hukuk Fakültesi", EndDate = "2020", ResumeId = _ids[1] },
                new Education { Id = 4, Name = "Ankara Lisesi", Department = "Fen Bilimleri", EndDate = "2014", ResumeId = _ids[1] }
                );
        }
    }
}
