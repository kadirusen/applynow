using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Title).IsRequired();


            builder.ToTable("Experiences");
        }
    }
}
