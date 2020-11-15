using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Seeds
{
    public class CompanySeed : IEntityTypeConfiguration<Company>
    {
        private readonly int[] _ids;

        public CompanySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company { Id = 1, Name = "Company X", Address = "Ankara/Türkiye" },
                new Company { Id = 2, Name = "Company Y", Address = "İstanbul/Türkiye" }
                );
        }
    }
}
