using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gear.Domain.Entities;

namespace Gear.Infrastructure.Data.Mapping
{
    internal class UserMappings : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TUser");

            builder.HasKey(x => x.Id);
        }
    }
}
