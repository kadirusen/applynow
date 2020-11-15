using System;
using ApplyNow.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplyNow.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        private readonly int[] _ids;

        public UserSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = _ids[0], UserName = "user1", Email= "user1@xyz.com", Password = "123" },
                new User { Id = _ids[1], UserName = "user2", Email = "user2@xyz.com", Password = "123" }
                );
        }
    }
}
