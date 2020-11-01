using Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class TagRoadmapRelationBuilder:BaseEntityBuilder<TagRoadmapRelation>
    {
        public override void Configure(EntityTypeBuilder<TagRoadmapRelation> builder)
        {
            base.Configure(builder);

            builder.Property(tr => tr.TagId).IsRequired();
            builder.Property(tr => tr.RoadmapId).IsRequired();
        }

        //public TagRoadmapRelationBuilder(EntityTypeBuilder<TagRoadmapRelation> builder)
        //{
        //    builder.HasKey(tr => tr.Id);
        //    builder.Property(tr => tr.Id).ValueGeneratedOnAdd();
        //    builder.Property(tr => tr.TagId).IsRequired();
        //    builder.Property(tr => tr.RoadmapId).IsRequired();
        //}
    }
}
