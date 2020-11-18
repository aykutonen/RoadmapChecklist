using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class RoadmapCopyBuilder : IEntityTypeConfiguration<RoadmapCopy>
    {
        public void Configure(EntityTypeBuilder<RoadmapCopy> builder)
        {
            builder.HasKey(rc => new { rc.SourceId, rc.TargetId });

            builder.HasOne(rc => rc.SourceRoudmap)
                .WithMany(r => r.Sources)
                .HasForeignKey(rc => rc.SourceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(rc => rc.TargetRoadmap)
                .WithMany(r => r.Targets)
                .HasForeignKey(rc => rc.TargetId)
                .OnDelete(DeleteBehavior.NoAction);
                

          
        }
    }
}
