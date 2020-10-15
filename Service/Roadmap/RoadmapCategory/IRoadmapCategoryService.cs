namespace Service.Roadmap.RoadmapCategory
{
    public interface IRoadmapCategoryService
    {
        ReturnModel<Entity.Domain.Roadmap.Roadmap> Create(Entity.Domain.Roadmap.RoadmapCategoryRelation roadmapCategoryEntity);
    }
}