using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class UserBuilder
    {
        public UserBuilder(EntityTypeBuilder<User> builder)
        {
            // fields
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();
            builder.Property(user => user.Name).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(100);
            builder.Property(user => user.Picture).HasMaxLength(255);
            builder.Property(user => user.Status).IsRequired();

            // relations
            builder.HasMany(user => user.Roadmaps)
                .WithOne(roadmap => roadmap.User)
                .HasForeignKey(roadmap => roadmap.User)
                .OnDelete(DeleteBehavior.Cascade) //ToDo: Ask should the roadmap delete the user when deleted ?
                .IsRequired();
        }
    }
}
