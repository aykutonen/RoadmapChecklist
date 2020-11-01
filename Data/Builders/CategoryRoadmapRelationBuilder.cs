using Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class CategoryRoadmapRelationBuilder : BaseEntityBuilder<CategoryRoadmapRelation>
    {
        public override void Configure(EntityTypeBuilder<CategoryRoadmapRelation> builder)
        {
            base.Configure(builder);
            builder.Property(cr => cr.CategoryId).IsRequired();
            builder.Property(cr => cr.RoadmapId).IsRequired();
        }

        //public CategoryRoadmapRelationBuilder(EntityTypeBuilder<CategoryRoadmapRelation> builder)
        //{
        //    builder.HasKey(cr => cr.Id);
        //    builder.Property(cr => cr.Id).ValueGeneratedOnAdd();
            
        //}
    }
}
