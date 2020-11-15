using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(200);

            builder.Property(x => x.Department).HasMaxLength(200);

            builder.ToTable("Educations");
        }
    }
}
