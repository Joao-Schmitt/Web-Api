using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gear.Domain.Entities;

namespace Gear.Infrastructure.Data.Mapping
{
    internal class UserMappings : IEntityTypeConfiguration<UsersCredentials>
    {
        public void Configure(EntityTypeBuilder<UsersCredentials> builder)
        {
            builder.ToTable("UsersCredentials");

            builder.HasKey(x => x.Id);
        }
    }
}
