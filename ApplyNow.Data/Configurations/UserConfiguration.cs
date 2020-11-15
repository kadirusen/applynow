using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Password).IsRequired();


            builder.ToTable("Users");
        }
    }
}
