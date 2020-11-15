using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.ToTable("Companies");
        }
    }
}
