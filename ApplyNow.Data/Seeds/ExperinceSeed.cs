using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Seeds
{
    public class ExperinceSeed :  IEntityTypeConfiguration<Experience>
    {
        private readonly int[] _ids;

        public ExperinceSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasData(
                new Experience { Id = 1, CompanyName = "X Firma", Title = "Yazılım Mühendisliği", StartDate = "2012", EndDate = "2015", ResumeId = _ids[0] },
                new Experience { Id = 2, CompanyName = "Y Firma", Title = "Avukat", StartDate = "2009", EndDate = "2017", ResumeId = _ids[1] },
                new Experience { Id = 3, CompanyName = "Z Firma", Title = "Danışman", StartDate = "2002", EndDate = "2009", ResumeId = _ids[1] }
                );
        }
    }
}
