using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class TagBuilder : BaseEntityBuilder<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(255);
            builder.Property(t => t.FriendlyUrl).IsRequired().HasMaxLength(300);

            // Relations
            builder.HasMany(t => t.RoadmapTags)
                .WithOne(rt => rt.Tag)
                .HasForeignKey(rt => rt.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        //public TagBuilder(EntityTypeBuilder<Tag> builder)
        //{
        //    builder.HasKey(t => t.Id);
        //    builder.Property(t => t.Id).ValueGeneratedOnAdd();
        //    builder.Property(t => t.Name).IsRequired().HasMaxLength(255);
        //    builder.Property(t => t.FriendlyUrl).IsRequired().HasMaxLength(300);

        //    // Relations
        //    builder.HasMany(t => t.RoadmapTags)
        //        .WithOne(rt => rt.Tag)
        //        .HasForeignKey(rt => rt.TagId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
