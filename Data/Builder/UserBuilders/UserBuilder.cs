using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class UserBuilder
    {
        public UserBuilder(EntityTypeBuilder<User> builder)
        {


            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();
            builder.Property(user => user.Name).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(150);
            builder.Property(user => user.Picture).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Status).IsRequired();

            //İlişkiler
            //Bir User'ın 1 birden fazla roadmap'i olabilir.
            builder.HasMany(user => user.Roadmap)
                .WithOne(roadmap => roadmap.User)
                .HasForeignKey(roadmap => roadmap.UserId)
                .OnDelete(DeleteBehavior.Cascade) //ToDo: Ask should the roadmap delete the user when deleted ?
                .IsRequired();


        }
    }
}
