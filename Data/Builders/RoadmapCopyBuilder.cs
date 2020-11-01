using Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class RoadmapCopyBuilder : BaseEntityBuilder<RoadmapCopy>
    {
        public override void Configure(EntityTypeBuilder<RoadmapCopy> builder)
        {
            base.Configure(builder);
            builder.Property(rc => rc.SourceId).IsRequired();
            builder.Property(rc => rc.TargetId).IsRequired();
        }
    }
}
