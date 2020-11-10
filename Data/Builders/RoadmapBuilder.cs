using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class RoadmapBuilder : BaseEntityBuilder<Roadmap>
    {
        public override void Configure(EntityTypeBuilder<Roadmap> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(500);
            builder.Property(r => r.Visibility).IsRequired().HasDefaultValue(1);

            // Relations
            builder.HasMany(r => r.Items)
                .WithOne(i => i.Roadmap)
                .HasForeignKey(i => i.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Source)
                .WithMany(sr => sr.Targets)
                .HasForeignKey(r => r.SourceId)
                .HasPrincipalKey(sr => sr.Id)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(r => r.Source)
            //    .WithOne(rc => rc.TargetRoadmap)
            //    .HasForeignKey<RoadmapCopy>(rc => rc.TargetId)
            //    .HasPrincipalKey<Roadmap>(r => r.Id)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(r => r.Targets)
            //    .WithOne(rc => rc.SourceRoudmap)
            //    .HasForeignKey(rc => rc.SourceId)
            //    .HasPrincipalKey(r => r.Id)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Categories)
                .WithOne(c => c.Roadmap)
                .HasForeignKey(c => c.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Tags)
                .WithOne(t => t.Roadmap)
                .HasForeignKey(t => t.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        //public RoadmapBuilder(EntityTypeBuilder<Roadmap> builder)
        //{
        //    builder.HasKey(r => r.Id);
        //    builder.Property(r => r.Id).ValueGeneratedOnAdd();
        //    builder.Property(r => r.Name).IsRequired().HasMaxLength(500);
        //    builder.Property(r => r.Status).IsRequired().HasDefaultValue(1);
        //    builder.Property(r => r.Visibility).IsRequired().HasDefaultValue(1);


        //    // Relations
        //    builder.HasMany(r => r.Items)
        //        .WithOne(i => i.Roadmap)
        //        .HasForeignKey(i => i.RoadmapId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasOne(r => r.Source)
        //        .WithOne(rc => rc.SourceRoudmap)
        //        .HasForeignKey<RoadmapCopy>(rc => rc.SourceId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasMany(r => r.Targets)
        //        .WithOne(rc => rc.TargetRoadmap)
        //        .HasForeignKey(rc => rc.TargetId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasMany(r => r.Categories)
        //        .WithOne(c => c.Roadmap)
        //        .HasForeignKey(c => c.RoadmapId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasMany(r => r.Tags)
        //        .WithOne(t => t.Roadmap)
        //        .HasForeignKey(t => t.RoadmapId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //}
    }
}
