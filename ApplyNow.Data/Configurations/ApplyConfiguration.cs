using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Configurations
{
    public class ApplyConfiguration : IEntityTypeConfiguration<Apply>
    {
        public void Configure(EntityTypeBuilder<Apply> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();


            builder.ToTable("Applys");
        }
    }
}
