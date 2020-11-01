using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class UserBuilder : BaseEntityBuilder<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Name).IsRequired().HasMaxLength(500);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(500);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Picture).HasMaxLength(255);

            // Relations
            builder.HasMany(u => u.Roadmaps)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        //public UserBuilder(EntityTypeBuilder<User> builder)
        //{
        //    builder.HasKey(u => u.Id);
        //    builder.Property(u => u.Id).ValueGeneratedOnAdd();
        //    builder.Property(u => u.Name).IsRequired().HasMaxLength(500);
        //    builder.Property(u => u.Email).IsRequired().HasMaxLength(500);
        //    builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        //    builder.Property(u => u.Picture).HasMaxLength(255);
        //    builder.Property(u => u.Status).IsRequired().HasDefaultValue(1);

        //    // Relations
        //    builder.HasMany(u => u.Roadmaps)
        //        .WithOne(r => r.User)
        //        .HasForeignKey(r => r.UserId)
        //        .OnDelete(DeleteBehavior.Cascade)
        //        .IsRequired();
        //}
    }
}
