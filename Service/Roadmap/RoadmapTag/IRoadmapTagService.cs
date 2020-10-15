namespace Service.Roadmap.RoadmapTag
{
    public interface IRoadmapTagService
    {
        ReturnModel<Entity.Domain.Roadmap.Roadmap> Create(Entity.Domain.Roadmap.RoadmapTagRelation roadmapTagEntity);
    }
}